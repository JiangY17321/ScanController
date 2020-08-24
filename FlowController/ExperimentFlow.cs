using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.IO;
using System.Text;
using System.Threading;

namespace FlowController
{
    /// <summary>
    /// A singleton which manages all the operations and executes these oprations
    /// one by one.
    /// </summary>
    public sealed class ExperimentFlow
    {
        static ExperimentFlow experimentFlow = null;
        /// <summary>
        /// Thread synchronization object for calls to this object
        /// </summary>
        static object synchCall = new object();

        /// <summary>
        /// Create Singleton instance of logger
        /// </summary>
        /// <returns></returns>
        public static ExperimentFlow GetInstance()
        {
            if (experimentFlow == null)
            {
                lock (synchCall)
                {
                    if (experimentFlow == null)
                        experimentFlow = new ExperimentFlow();
                }
            }

            return experimentFlow;
        }

        #region Variables
        private SynQueue<ExperimentOperation> experimentQueue;
        private Thread experimentProcessingThread;
        private Mutex threadCreatingMutex;
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        private ExperimentFlow()
        {
            experimentQueue = new SynQueue<ExperimentOperation>();
            experimentProcessingThread = null;
            threadCreatingMutex = new Mutex();
        }

        public bool RunNewExperiment(ExperimentOperation experimentOperation)
        {
            if (experimentQueue.Count != 0) return false;
            experimentQueue.Enqueue(experimentOperation);

            threadCreatingMutex.WaitOne();
            if(experimentProcessingThread==null)
            {
                experimentProcessingThread = new Thread(ExperimentProcessingProc);
                experimentProcessingThread.IsBackground = true;
                experimentProcessingThread.Start();
            }
            threadCreatingMutex.ReleaseMutex();

            return true;
        }

        private void ExperimentProcessingProc()
        {
            while(true)
            {
                ExperimentOperation experimentOperation= experimentQueue.Dequeue();
                RunExperimentOperation(experimentOperation);
            }
        }

        private void RunExperimentOperation(ExperimentOperation experimentOperation)
        {
            if (experimentOperation == null) return;
            RunOperation(experimentOperation);
        }

        private void RunOperation(Operation operation)
        {
            try
            {
                if (operation == null) return;
                operation.Run();
                foreach (Operation subOperation in operation.ChildOperations)
                {
                    RunOperation(subOperation);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);
            }
        }

        public void SaveOperationTreeToFile(ExperimentOperation experimentOperation,
            string fileName)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
            };

            string content=JsonConvert.SerializeObject(experimentOperation, settings);
            FileStream fileStream = new FileStream(fileName, FileMode.Create);
            byte[] bytesContent = Encoding.UTF8.GetBytes(content);
            fileStream.Write(bytesContent, 0, bytesContent.Length);
            fileStream.Close();
        }

        public ExperimentOperation LoadOperationTreeFromFile(string fileName)
        {
            FileStream fileStream = new FileStream(fileName, FileMode.Open);
            byte[] content = new byte[fileStream.Length];
            fileStream.Read(content, 0, content.Length);

            string stringContent = Encoding.UTF8.GetString(content);

            ExperimentOperation experimentOperation=
                JsonConvert.DeserializeObject<ExperimentOperation>(stringContent);
            return experimentOperation;
        }
    }
}

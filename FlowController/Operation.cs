using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading;

namespace FlowController
{
    public class ExportAttribute : Attribute { }

    [JsonConverter(typeof(OperationConverter))]
    public abstract class Operation
    {
        #region EXPORT
        [Export]
        public OperationType OperationType { get; }

        [Export]
        public List<Operation> ChildOperations { get; set; }

        [Export]
        public string Name { get; set; }
        #endregion

        private static ManualResetEvent manualResetEvent;
        public bool IsRunning { get; private set; }
        public Operation(OperationType operationType)
        {
            OperationType = operationType;
            ChildOperations = new List<Operation>();
            IsRunning = false;
        }

        internal bool StartRun()
        {
            if (manualResetEvent == null)
            {
                manualResetEvent = new ManualResetEvent(true);
            }
            manualResetEvent.Reset();
            IsRunning = true;
            bool result = Run();
            manualResetEvent.WaitOne();
            IsRunning = false;
            return result;
        }

        public virtual bool Run()
        {
            RunFinished();
            return true;
        }

        protected void RunFinished()
        {
            manualResetEvent.Set();
        }
    }
}

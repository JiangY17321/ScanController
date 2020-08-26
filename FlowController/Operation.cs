using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading;

namespace FlowController
{
    [JsonConverter(typeof(OperationConverter))]
    public abstract class Operation
    {
        public OperationType OperationType { get; }
      
        public List<Operation> ChildOperations { get; set; }

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

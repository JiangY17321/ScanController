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

        public Operation Parent { get; set; }

        /// <summary>
        /// level of root node is 0, level of root node's child is 1; 
        /// </summary>
        public int Level
        {
            get
            {
                int currentLevel = 0;
                Operation temp = Parent;
                while(temp!=null)
                {
                    currentLevel++;
                    temp = temp.Parent;
                }
                return currentLevel;
            }
        }

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

        public Operation GetParentOperationByType(Type operationType)
        {
            Operation currentOperation = Parent;
            while(currentOperation!=null)
            {
                if(currentOperation.GetType()== operationType ||
                    operationType.GetType().IsSubclassOf(operationType))
                {
                    return currentOperation;
                }
                currentOperation = currentOperation.Parent;
            }
            return null;
        }

        public Operation GetLastSiblingOperationByType(Type operationType)
        {
            return GetLastSiblingOperationByType(this, operationType);
        }

        private static Operation GetLastSiblingOperationByType(Operation self, Type operationType)
        {
            if (self == null) return null;
            if (self.Parent == null) return null;
            int index = self.Parent.ChildOperations.IndexOf(self);
            if (index == -1) return null;
            for(int i=index;i>=0;i--)
            {
                if (self.Parent.ChildOperations[i] == null) continue;
                Type siblingType = self.Parent.ChildOperations[i].GetType();
                if(siblingType== operationType || operationType.IsSubclassOf(siblingType))
                {
                    return self.Parent.ChildOperations[i];
                }
            }
            return GetLastSiblingOperationByType(self.Parent, operationType);
        }

        public bool IsUnderBackgroundOperation()
        {

        }
    }
}

using System.Collections.Generic;

namespace FlowController
{
    public abstract class Operation
    {
        public OperationType OperationType { get; }

        public List<Operation> ChildOperations { get; }

        public Operation(OperationType operationType)
        {
            OperationType = operationType;
            ChildOperations = new List<Operation>();
        }

        public virtual bool Run()
        {
            return true;
        }
    }
}

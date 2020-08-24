using Newtonsoft.Json;
using System.Collections.Generic;

namespace FlowController
{
    [JsonConverter(typeof(OperationConverter))]
    public abstract class Operation
    {
        public OperationType OperationType { get; }

      
        public List<Operation> ChildOperations { get; set; }

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

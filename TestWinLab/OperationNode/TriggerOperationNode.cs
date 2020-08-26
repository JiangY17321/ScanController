using FlowController;

namespace TestWinLab
{
    public class TriggerOperationNode : OperationNode
    {
        public override string Content
        {
            get
            {
                if (TriggerOperation != null)
                    return TriggerOperation.Name;
                return content;
            }
            set
            {
                content = value;
                if (TriggerOperation != null)
                    TriggerOperation.Name = value;
                OnPropertyChanged("Content");
            }
        }

        public TriggerOperation TriggerOperation
        {
            get
            {
                return Operation as TriggerOperation;
            }
        }

        public TriggerOperationNode(string content)
        {
            ParentNode = null;
            Operation = null;
            Content = content;
            Operation = new TriggerOperation();
            TriggerOperation.Name = content;
        }

        public TriggerOperationNode(TriggerOperation triggerOperation)
        {
            Operation = triggerOperation;
            ParentNode = null;
        }
    }
}

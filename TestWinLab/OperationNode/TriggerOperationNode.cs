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
                    return TriggerOperation.TriggerName;
                return content;
            }
            set
            {
                content = value;
                if (TriggerOperation != null)
                    TriggerOperation.TriggerName = value;
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
            TriggerOperation.TriggerName = content;
        }

        public TriggerOperationNode(TriggerOperation triggerOperation)
        {
            Operation = triggerOperation;
            ParentNode = null;
        }
    }
}

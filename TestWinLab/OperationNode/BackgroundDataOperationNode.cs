using FlowController;

namespace TestWinLab
{
    public class BackgroundDataOperationNode : OperationNode
    {
        public override string Content
        {
            get
            {
                if (BackgroundDataOperation != null)
                    return BackgroundDataOperation.BackgroundDataName;
                return content;
            }
            set
            {
                content = value;
                if (BackgroundDataOperation != null)
                    BackgroundDataOperation.BackgroundDataName = value;
                OnPropertyChanged("Content");
            }
        }

        public BackgroundDataOperation BackgroundDataOperation
        {
            get
            {
                return Operation as BackgroundDataOperation;
            }
        }

        public BackgroundDataOperationNode(string content)
        {
            ParentNode = null;
            Operation = null;
            Content = content;
            Operation = new BackgroundDataOperation();
            BackgroundDataOperation.BackgroundDataName = content;
        }

        public BackgroundDataOperationNode(BackgroundDataOperation backgroundDataOperation)
        {
            Operation = backgroundDataOperation;
            ParentNode = null;
        }
    }
}

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
                    return BackgroundDataOperation.Name;
                return content;
            }
            set
            {
                content = value;
                if (BackgroundDataOperation != null)
                    BackgroundDataOperation.Name = value;
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
            BackgroundDataOperation.Name = content;
        }

        public BackgroundDataOperationNode(BackgroundDataOperation backgroundDataOperation)
        {
            Operation = backgroundDataOperation;
            ParentNode = null;
        }
    }
}

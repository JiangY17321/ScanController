using FinchFlowController;

namespace TestWinLab
{
    public class FinchScanOperationNode : OperationNode
    {
        public override string Content
        {
            get
            {
                if (FinchScanOperation != null)
                    return FinchScanOperation.Name;
                return content;
            }
            set
            {
                content = value;
                if (FinchScanOperation != null)
                    FinchScanOperation.Name = value;
                OnPropertyChanged("Content");
            }
        }

        public FinchScanOperation FinchScanOperation
        {
            get
            {
                return Operation as FinchScanOperation;
            }
        }


        public FinchScanOperationNode(string content)
        {
            ParentNode = null;
            Operation = null;
            Content = content;
            Operation = new FinchScanOperation();
            FinchScanOperation.Name = content;
        }

        public FinchScanOperationNode(FinchScanOperation finchScanOperation)
        {
            Operation = finchScanOperation;
            ParentNode = null;
        }
    }
}

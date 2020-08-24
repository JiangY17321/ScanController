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
                    return FinchScanOperation.ScanName;
                return content;
            }
            set
            {
                content = value;
                if (FinchScanOperation != null)
                    FinchScanOperation.ScanName = value;
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
            FinchScanOperation.ScanName = content;
        }

        public FinchScanOperationNode(FinchScanOperation finchScanOperation)
        {
            Operation = finchScanOperation;
            ParentNode = null;
        }
    }
}

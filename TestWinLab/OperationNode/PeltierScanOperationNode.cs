using FinchFlowController;

namespace TestWinLab
{
    public class PeltierScanOperationNode : OperationNode
    {
        public override string Content
        {
            get
            {
                if (PeltierScanOperation != null)
                    return PeltierScanOperation.Name;
                return content;
            }
            set
            {
                content = value;
                if (PeltierScanOperation != null)
                    PeltierScanOperation.Name = value;
                OnPropertyChanged("Content");
            }
        }

        public PeltierScanOperation PeltierScanOperation
        {
            get
            {
                return Operation as PeltierScanOperation;
            }
        }


        public PeltierScanOperationNode(string content)
        {
            ParentNode = null;
            Operation = null;
            Content = content;
            Operation = new PeltierScanOperation();
            PeltierScanOperation.Name = content;
        }

        public PeltierScanOperationNode(PeltierScanOperation peltierScanOperation)
        {
            Operation = peltierScanOperation;
            ParentNode = null;
        }
    }
}

using FlowController;

namespace TestWinLab
{
    public class DataOperationNode : OperationNode
    {
        public override string Content
        {
            get
            {
                if (DataOperation != null)
                    return DataOperation.DataName;
                return content;
            }
            set
            {
                content = value;
                if (DataOperation != null)
                    DataOperation.DataName = value;
                OnPropertyChanged("Content");
            }
        }

        public DataOperation DataOperation
        {
            get
            {
                return Operation as DataOperation;
            }
        }

        public DataOperationNode(string content)
        {
            ParentNode = null;
            Operation = null;
            Content = content;
            Operation = new DataOperation();
            DataOperation.DataName = content;
        }

        public DataOperationNode(DataOperation dataOperation)
        {
            Operation = dataOperation;
            ParentNode = null;
        }
    }
}

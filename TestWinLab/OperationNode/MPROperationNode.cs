using FlowController;

namespace TestWinLab
{
    public class MPROperationNode : OperationNode
    {
        public override string Content
        {
            get
            {
                if (MPROperation != null)
                    return MPROperation.Name;
                return content;
            }
            set
            {
                content = value;
                if (MPROperation != null)
                    MPROperation.Name = value;
                OnPropertyChanged("Content");
            }
        }

        public MPROperation MPROperation
        {
            get
            {
                return Operation as MPROperation;
            }
        }


        public MPROperationNode(string content)
        {
            ParentNode = null;
            Operation = null;
            Content = content;
            Operation = new MPROperation();
            MPROperation.Name = content;
        }

        public MPROperationNode(MPROperation mprOperation)
        {
            Operation = mprOperation;
            ParentNode = null;
        }
    }
}

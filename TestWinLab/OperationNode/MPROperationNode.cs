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
                    return MPROperation.MPRName;
                return content;
            }
            set
            {
                content = value;
                if (MPROperation != null)
                    MPROperation.MPRName = value;
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
            MPROperation.MPRName = content;
        }

        public MPROperationNode(MPROperation mprOperation)
        {
            Operation = mprOperation;
            ParentNode = null;
        }
    }
}

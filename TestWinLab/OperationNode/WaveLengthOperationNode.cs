using FlowController;

namespace TestWinLab
{
    public class WaveLengthOperationNode : OperationNode
    {
        public override string Content
        {
            get
            {
                if (WaveLengthOperation != null)
                    return WaveLengthOperation.WaveLengthName;
                return content;
            }
            set
            {
                content = value;
                if (WaveLengthOperation != null)
                    WaveLengthOperation.WaveLengthName = value;
                OnPropertyChanged("Content");
            }
        }

        public WaveLengthOperation WaveLengthOperation
        {
            get
            {
                return Operation as WaveLengthOperation;
            }
        }


        public WaveLengthOperationNode(string content)
        {
            ParentNode = null;
            Operation = null;
            Content = content;
            Operation = new WaveLengthOperation();
            WaveLengthOperation.WaveLengthName = content;
        }

        public WaveLengthOperationNode(WaveLengthOperation waveLengthOperation)
        {
            Operation = waveLengthOperation;
            ParentNode = null;
        }
    }
}

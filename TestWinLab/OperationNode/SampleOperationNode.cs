using FlowController;

namespace TestWinLab
{
    public class SampleOperationNode : OperationNode
    {
        public override string Content
        {
            get
            {
                if (SampleOperation != null)
                    return SampleOperation.SampleName;
                return content;
            }
            set
            {
                content = value;
                if (SampleOperation != null)
                    SampleOperation.SampleName = value;
                OnPropertyChanged("Content");
            }
        }

        public SampleOperation SampleOperation
        {
            get
            {
                return Operation as SampleOperation;
            }
        }

        public SampleOperationNode(string content)
        {
            ParentNode = null;
            Operation = null;
            Content = content;
            Operation = new SampleOperation();
            SampleOperation.SampleName = content;
        }

        public SampleOperationNode(SampleOperation sampleOperation)
        {
            Operation = sampleOperation;
            ParentNode = null;
        }
    }
}

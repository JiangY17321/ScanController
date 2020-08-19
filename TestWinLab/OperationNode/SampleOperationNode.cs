using FlowController;

namespace TestWinLab
{
    public class SampleOperationNode : OperationNode
    {
        public SampleOperationNode(string content)
        {
            ParentNode = null;
            Operation = null;
            Content = content;
            Operation = new SampleOperation();
        }
    }
}

using FlowController;

namespace TestWinLab
{
    public class ScanOperationNode : OperationNode
    {
        public ScanOperationNode(string content)
        {
            ParentNode = null;
            Operation = null;
            Content = content;
            Operation = new ScanOperation();
        }
    }
}

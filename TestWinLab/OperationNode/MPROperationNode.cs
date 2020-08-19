using FlowController;

namespace TestWinLab
{
    public class MPROperationNode : OperationNode
    {
        public MPROperationNode(string content)
        {
            ParentNode = null;
            Operation = null;
            Content = content;
            Operation = new MPROperation();
        }
    }
}

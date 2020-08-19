using FlowController;

namespace TestWinLab
{
    public class BackgroundDataOperationNode : OperationNode
    {
        public BackgroundDataOperationNode(string content)
        {
            ParentNode = null;
            Operation = null;
            Content = content;
            Operation = new BackgroundDataOperation();
        }
    }
}

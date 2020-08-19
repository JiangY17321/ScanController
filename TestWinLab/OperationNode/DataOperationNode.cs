using FlowController;

namespace TestWinLab
{
    public class DataOperationNode : OperationNode
    {
        public DataOperationNode(string content)
        {
            ParentNode = null;
            Operation = null;
            Content = content;
            Operation = new DataOperation();
        }
    }
}

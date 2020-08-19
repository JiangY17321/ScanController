using FlowController;

namespace TestWinLab
{
    public class TimeOperationNode : OperationNode
    {
        public TimeOperationNode(string content)
        {
            ParentNode = null;
            Operation = null;
            Content = content;
            Operation = new TimeOperation();
        }
    }
}

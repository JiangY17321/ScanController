using FlowController;

namespace TestWinLab
{
    public class TriggerOperationNode : OperationNode
    {
        public TriggerOperationNode(string content)
        {
            ParentNode = null;
            Operation = null;
            Content = content;
            Operation = new TriggerOperation();
        }
    }
}

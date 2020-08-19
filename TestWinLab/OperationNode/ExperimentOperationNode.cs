using FlowController;

namespace TestWinLab
{
    public class ExperimentOperationNode:OperationNode
    {
        public ExperimentOperationNode(string content)
        {
            ParentNode = null;
            Operation = null;
            Content = content;
            Operation = new ExperimentOperation();
        }
    }
}

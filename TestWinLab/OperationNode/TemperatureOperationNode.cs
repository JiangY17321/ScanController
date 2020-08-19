using FlowController;

namespace TestWinLab
{
    public class TemperatureOperationNode : OperationNode
    {
        public TemperatureOperationNode(string content)
        {
            ParentNode = null;
            Operation = null;
            Content = content;
            Operation = new TemperatureOperation();
        }
    }
}

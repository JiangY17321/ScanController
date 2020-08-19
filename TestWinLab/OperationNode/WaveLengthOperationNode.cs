using FlowController;

namespace TestWinLab
{
    public class WaveLengthOperationNode : OperationNode
    {
        public WaveLengthOperationNode(string content)
        {
            ParentNode = null;
            Operation = null;
            Content = content;
            Operation = new WaveLengthOperation();
        }
    }
}

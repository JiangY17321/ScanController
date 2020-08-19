using FlowController;

namespace TestWinLab
{
    public class GeneralParamOperationNode : OperationNode
    {
        public GeneralParamOperationNode(string content)
        {
            ParentNode = null;
            Operation = null;
            Content = content;
            Operation = new GeneralParamOperation();
        }
    }
}

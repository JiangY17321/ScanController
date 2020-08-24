using FinchFlowController;
using SimInstCtrl;

namespace TestWinLab
{
    public class ScanOperationNode : OperationNode
    {
        public ScanOperationNode(string content,InstCtrl instCtrl)
        {
            ParentNode = null;
            Operation = null;
            Content = content;
            Operation = new FinchScanOperation();
            (Operation as FinchScanOperation).Init(instCtrl);
        }
    }
}

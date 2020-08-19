using FinchFlowController;
using FlowController;

namespace TestWinLab
{
    public class GeneralParamOperationNode : OperationNode
    {
        public int ScanSpeed
        {
            get
            {
                return (Operation as FastScanParamOperation).ScanSpeed;
            }
            set
            {
                if(ScanSpeed != value)
                {
                    (Operation as FastScanParamOperation).ScanSpeed = value;
                    OnPropertyChanged("ScanSpeed");
                }
            }
        }

        public int Resolution
        {
            get
            {
                return (Operation as FastScanParamOperation).Resolution;
            }
            set
            {
                if (Resolution != value)
                {
                    (Operation as FastScanParamOperation).Resolution = value;
                    OnPropertyChanged("Resolution");
                }
            }
        }
        public GeneralParamOperationNode(string content)
        {
            ParentNode = null;
            Operation = null;
            Content = content;
            Operation = new FastScanParamOperation();
        }
    }
}

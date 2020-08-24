using FinchFlowController;
using FlowController;

namespace TestWinLab
{
    public class FastScanParamOperationNode : OperationNode
    {
        public override string Content
        {
            get
            {
                if (FastScanParamOperation != null)
                    return FastScanParamOperation.GeneralParamName;
                return content;
            }
            set
            {
                content = value;
                if (FastScanParamOperation != null)
                    FastScanParamOperation.GeneralParamName = value;
                OnPropertyChanged("Content");
            }
        }

        public FastScanParamOperation FastScanParamOperation
        {
            get
            {
                return Operation as FastScanParamOperation;
            }
        }

        private int scanSpeed { get; set; }
        public int ScanSpeed
        {
            get
            {
                if (FastScanParamOperation != null)
                    return FastScanParamOperation.ScanSpeed;
                return scanSpeed;
            }
            set
            {
                scanSpeed = value;
                if (FastScanParamOperation != null)
                    FastScanParamOperation.ScanSpeed = scanSpeed;
                OnPropertyChanged("ScanSpeed");
            }
        }

        private int resolution { get; set; }
        public int Resolution
        {
            get
            {
                if (FastScanParamOperation != null)
                    return FastScanParamOperation.Resolution;
                return resolution;
            }
            set
            {
                resolution = value;
                if (FastScanParamOperation != null)
                    FastScanParamOperation.Resolution = resolution;
                OnPropertyChanged("Resolution");
            }
        }

        public FastScanParamOperationNode(string content)
        {
            ParentNode = null;
            Operation = null;
            Content = content;
            Operation = new FastScanParamOperation();
            FastScanParamOperation.GeneralParamName = content;
        }

        public FastScanParamOperationNode(FastScanParamOperation fastScanParamOperation)
        {
            Operation = fastScanParamOperation;
            ParentNode = null;
        }
    }
}

using FlowController;

namespace FinchFlowController
{
    public class FastScanParamOperation:GeneralParamOperation
    {
        public int ScanSpeed { get; set; }
        public int Resolution { get; set; }
        public FastScanParamOperation()
        {
            ScanSpeed = 1;
            Resolution = 64;
        }
    }
}

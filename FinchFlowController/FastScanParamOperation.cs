using FlowController;

namespace FinchFlowController
{
    public class FastScanParamOperation:GeneralParamOperation
    {
        [Export]
        public int ScanSpeed { get; set; }
        [Export]
        public int Resolution { get; set; }

        public FastScanParamOperation()
        {
            ScanSpeed = 1;
            Resolution = 64;
        }
    }
}

using FlowController;
using SimInstCtrl;

namespace FinchFlowController
{
    public class FinchScanOperation:ScanOperation
    {
        private InstCtrl instCtrl;
        public FinchScanOperation(InstCtrl instCtrl)
        {
            this.instCtrl = instCtrl;
        }


        public override bool Run()
        {
            System.Diagnostics.Debug.WriteLine("FinchScanOperation Start Data collection");
            return true;
        }
    }
}

using FlowController;

namespace FinchFlowController
{
    public class FinchScanOperation:ScanOperation
    {
        public int ScanSpeed { get; set; }

        public int Resolution { get; set; }

        public FinchScanOperation()
        {
           
        }

        public override bool Run()
        {
            System.Diagnostics.Debug.WriteLine("FinchScanOperation Start Data collection");
            InstCtrlHandler.GetInstance().PerformScan_SinglePoint(this);
            return true;
        }

        public override void ScanCompelete()
        {
            System.Diagnostics.Debug.WriteLine("ScanCompelete!");
            RunFinished();
        }

        public override void ScanFailed(int errorNum)
        {
            System.Diagnostics.Debug.WriteLine("ScanFailed!!!");
        }

        public override void DataReceived_SinglePoint(double value)
        {
            System.Diagnostics.Debug.WriteLine("SinglePoint:"+value);
        }
    }
}

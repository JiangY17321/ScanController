using FlowController;
using SimInstCtrl;

namespace FinchFlowController
{
    public class FinchScanOperation:ScanOperation, IInstctrlScanCallBack
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


        public void ScanCompelete()
        {
            System.Diagnostics.Debug.WriteLine("ScanCompelete!");
            RunFinished();
        }

        public void ScanFailed()
        {
            System.Diagnostics.Debug.WriteLine("ScanFailed!!!");
        }

        /// <summary>
        /// auto-get the data from InstCtrl 
        /// </summary>
        public void DataReceived_AutoGet()
        {

        }

        public void DataReceived_SinglePoint(double value)
        {
            System.Diagnostics.Debug.WriteLine("SinglePoint:"+value);
        }

        public void DataReceived_DoublePoint(double xValue, double yValue)
        {

        }

        public void DataReceived_DoublePoint_Arrays(double[] xValues, double[] yValues)
        {

        }
    }
}

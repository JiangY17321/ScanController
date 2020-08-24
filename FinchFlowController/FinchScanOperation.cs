using FlowController;
using SimInstCtrl;

namespace FinchFlowController
{
    public class FinchScanOperation:ScanOperation
    {

        public int ScanSpeed { get; set; }

        public int Resolution { get; set; }

        private InstCtrl instCtrl;
        public FinchScanOperation()
        {
           
        }

        public void Init(InstCtrl instCtrl)
        {
            this.instCtrl = instCtrl;
            instCtrl.ScanCompelete_CallBack += ScanCompelete;
            instCtrl.ScanFailed_CallBack += ScanFailed;
            instCtrl.AutoGet_CallBack += DataReceived_AutoGet;
            instCtrl.SinglePoint_CallBack += DataReceived_SinglePoint;
            instCtrl.DoublePoint_CallBack += DataReceived_DoublePoint;
            instCtrl.DoublePoint_Arrays_CallBack += DataReceived_DoublePoint_Arrays;
        }


        public override bool Run()
        {
            System.Diagnostics.Debug.WriteLine("FinchScanOperation Start Data collection");
            instCtrl.PerformScan_SinglePoint();
            return true;
        }


        private void ScanCompelete()
        {
            System.Diagnostics.Debug.WriteLine("ScanCompelete!");
        }

        private void ScanFailed()
        {
            System.Diagnostics.Debug.WriteLine("ScanFailed!!!");
        }

        /// <summary>
        /// auto-get the data from InstCtrl 
        /// </summary>
        private void DataReceived_AutoGet()
        {

        }

        private void DataReceived_SinglePoint(double value)
        {
            System.Diagnostics.Debug.WriteLine("SinglePoint:"+value);
        }

        private void DataReceived_DoublePoint(double xValue, double yValue)
        {

        }

        private void DataReceived_DoublePoint_Arrays(double[] xValues, double[] yValues)
        {

        }
    }
}

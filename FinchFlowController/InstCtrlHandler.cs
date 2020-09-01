using FlowController;
using SimInstCtrl;

namespace FinchFlowController
{
    public class InstCtrlHandler
    {
        #region Singleton
        static InstCtrlHandler instCtrlHandler = null;
        /// <summary>
        /// Thread synchronization object for calls to this object
        /// </summary>
        static object synchCall = new object();

        /// <summary>
        /// Create Singleton instance of logger
        /// </summary>
        /// <returns></returns>
        public static InstCtrlHandler GetInstance()
        {
            if (instCtrlHandler == null)
            {
                lock (synchCall)
                {
                    if (instCtrlHandler == null)
                        instCtrlHandler = new InstCtrlHandler();
                }
            }
            return instCtrlHandler;
        }
        #endregion

        
        private ScanOperation currentScanOperation;

        public void SetInstCtrl(InstCtrl instCtrl)
        {
            if (instCtrl == this.instCtrl) return;
            if (this.instCtrl != null)
            {
                this.instCtrl.ScanCompelete_CallBack -= ScanCompelete;
                this.instCtrl.ScanFailed_CallBack -= ScanFailed;
                this.instCtrl.AutoGet_CallBack -= DataReceived_AutoGet;
                this.instCtrl.SinglePoint_CallBack -= DataReceived_SinglePoint;
                this.instCtrl.DoublePoint_CallBack -= DataReceived_DoublePoint;
                this.instCtrl.DoublePoint_Arrays_CallBack -= DataReceived_DoublePoint_Arrays;
            }
            this.instCtrl = instCtrl;
            instCtrl.ScanCompelete_CallBack += ScanCompelete;
            instCtrl.ScanFailed_CallBack += ScanFailed;
            instCtrl.AutoGet_CallBack += DataReceived_AutoGet;
            instCtrl.SinglePoint_CallBack += DataReceived_SinglePoint;
            instCtrl.DoublePoint_CallBack += DataReceived_DoublePoint;
            instCtrl.DoublePoint_Arrays_CallBack += DataReceived_DoublePoint_Arrays;
        }

        private void ScanCompelete()
        {
            if(currentScanOperation != null)
            {
                currentScanOperation.ScanCompelete();
            }
        }

        private void ScanFailed()
        {
            if (currentScanOperation != null)
            {
                currentScanOperation.ScanFailed(0);
            }
        }

        /// <summary>
        /// auto-get the data from InstCtrl 
        /// </summary>
        private void DataReceived_AutoGet()
        {
            if (currentScanOperation != null)
            {
                currentScanOperation.DataReceived_AutoGet();
            }
        }

        private void DataReceived_SinglePoint(double value)
        {
            if (currentScanOperation != null)
            {
                currentScanOperation.DataReceived_SinglePoint(value);
            }
        }

        private void DataReceived_DoublePoint(double xValue, double yValue)
        {
            if (currentScanOperation != null)
            {
                currentScanOperation.DataReceived_DoublePoint(xValue, yValue);
            }
        }

        private void DataReceived_DoublePoint_Arrays(double[] xValues, double[] yValues)
        {
            if (currentScanOperation != null)
            {
                currentScanOperation.DataReceived_DoublePoint_Arrays(xValues, yValues);
            }
        }

        public void PerformScan_SinglePoint(ScanOperation scanOperation)
        {
            if(instCtrl!=null)
            {
                currentScanOperation = scanOperation;
                instCtrl.PerformScan_SinglePoint();
            }
        }
    }
}

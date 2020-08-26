using FlowController;
using SimInstCtrl;

namespace FinchFlowController
{
    public class InstCtrlHandler
    {
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


        private InstCtrl instCtrl;
        private IInstctrlScanCallBack instCtrlCallBack;

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
            if(instCtrlCallBack!=null)
            {
                instCtrlCallBack.ScanCompelete();
            }
        }

        private void ScanFailed()
        {
            if (instCtrlCallBack != null)
            {
                instCtrlCallBack.ScanFailed();
            }
        }

        /// <summary>
        /// auto-get the data from InstCtrl 
        /// </summary>
        private void DataReceived_AutoGet()
        {
            if (instCtrlCallBack != null)
            {
                instCtrlCallBack.DataReceived_AutoGet();
            }
        }

        private void DataReceived_SinglePoint(double value)
        {
            if (instCtrlCallBack != null)
            {
                instCtrlCallBack.DataReceived_SinglePoint(value);
            }
        }

        private void DataReceived_DoublePoint(double xValue, double yValue)
        {
            if (instCtrlCallBack != null)
            {
                instCtrlCallBack.DataReceived_DoublePoint(xValue, yValue);
            }
        }

        private void DataReceived_DoublePoint_Arrays(double[] xValues, double[] yValues)
        {
            if (instCtrlCallBack != null)
            {
                instCtrlCallBack.DataReceived_DoublePoint_Arrays(xValues, yValues);
            }
        }

        public void PerformScan_SinglePoint(IInstctrlScanCallBack instCtrlCallBack)
        {
            if(instCtrl!=null)
            {
                this.instCtrlCallBack = instCtrlCallBack;
                instCtrl.PerformScan_SinglePoint();
            }
        }
    }
}

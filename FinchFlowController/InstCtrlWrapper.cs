using FlowController;
using SimInstCtrl;
using System;
using System.Threading;

namespace FinchFlowController
{
    public class InstCtrlWrapper
    {
        #region Singleton
        static InstCtrlWrapper instCtrlWrapper = null;
        /// <summary>
        /// Thread synchronization object for calls to this object
        /// </summary>
        static object synchCall = new object();

        /// <summary>
        /// Create Singleton instance of logger
        /// </summary>
        /// <returns></returns>
        public static InstCtrlWrapper GetInstance()
        {
            if (instCtrlWrapper == null)
            {
                lock (synchCall)
                {
                    if (instCtrlWrapper == null)
                    {
                        instCtrlWrapper = new InstCtrlWrapper();
                    }
                }
            }
            return instCtrlWrapper;
        }
        #endregion

        private ScanOperation _currentScanOperation;
        private InstCtrl _instCtrl;
        private STAThread _staThread;
        private delegate void NoReturnAndParamDelegate();
        private SynQueue<NoReturnAndParamDelegate> _callbackQueue;
        private Thread _callBackProcessingThread;

        private InstCtrlWrapper()
        {
            CreateCallBackThreadQueue();
            CreateSTAThread();
            CreateInstCtrl();
        }

        private void CreateCallBackThreadQueue()
        {
            _callbackQueue = new SynQueue<NoReturnAndParamDelegate>();
            _callBackProcessingThread = new Thread(InstCtrlCallbackThread);
            _callBackProcessingThread.IsBackground = true;
            _callBackProcessingThread.Start();
        }

        private void InstCtrlCallbackThread()
        {
            while(true)
            {
                NoReturnAndParamDelegate callbackFunction = _callbackQueue.Dequeue();
                if(callbackFunction!=null)
                {
                    try
                    {
                        callbackFunction.Invoke();
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine(ex.Message+" "+ex.StackTrace);
                    }
                }
            }
        }

        private void CreateSTAThread()
        {
            if (_staThread == null)
            {
                _staThread = new STAThread();
            }
        }

        private void CreateInstCtrl()
        {
            _staThread.Invoke(new NoReturnAndParamDelegate(() =>
            {
                _instCtrl = new InstCtrl();
                _instCtrl.ScanCompelete_CallBack += ScanCompelete;
                _instCtrl.ScanFailed_CallBack += ScanFailed;
                _instCtrl.AutoGet_CallBack += DataReceived_AutoGet;
                _instCtrl.SinglePoint_CallBack += DataReceived_SinglePoint;
                _instCtrl.DoublePoint_CallBack += DataReceived_DoublePoint;
                _instCtrl.DoublePoint_Arrays_CallBack += DataReceived_DoublePoint_Arrays;
            }), null);
        }

        private void DataReceived_AutoGet()
        {

        }

        private void ScanCompelete()
        {
            if (_currentScanOperation != null && _callbackQueue!=null)
            {
                _callbackQueue.Enqueue(new NoReturnAndParamDelegate(() =>
                {
                    _currentScanOperation.ScanCompelete();
                }));
            }
        }

        private void ScanFailed()
        {
            if (_currentScanOperation != null && _callbackQueue != null)
            {
                _callbackQueue.Enqueue(new NoReturnAndParamDelegate(() =>
                {
                    _currentScanOperation.ScanFailed(0);
                }));
            }
        }

        private void DataReceived_SinglePoint(double value)
        {
            if (_currentScanOperation != null && _callbackQueue != null)
            {
                _callbackQueue.Enqueue(new NoReturnAndParamDelegate(() =>
                {
                    _currentScanOperation.DataReceived_SinglePoint(value);
                }));
            }
        }

        private void DataReceived_DoublePoint(double xValue, double yValue)
        {
            if (_currentScanOperation != null && _callbackQueue != null)
            {
                _callbackQueue.Enqueue(new NoReturnAndParamDelegate(() =>
                {
                    _currentScanOperation.DataReceived_DoublePoint(xValue, yValue);
                }));
            }
        }

        private void DataReceived_DoublePoint_Arrays(double[] xValues, double[] yValues)
        {
            if (_currentScanOperation != null && _callbackQueue != null)
            {
                _callbackQueue.Enqueue(new NoReturnAndParamDelegate(() =>
                {
                    _currentScanOperation.DataReceived_DoublePoint_Arrays(xValues, yValues);
                }));
            }
        }

        public bool PerformScan_SinglePoint(ScanOperation scanOperation)
        {
            if (_instCtrl == null) return false;
            _currentScanOperation = scanOperation;
            _staThread.Invoke(new NoReturnAndParamDelegate(() =>
            {
                _instCtrl.PerformScan_SinglePoint();
            }), null);
            return true;
        }

        public bool PerformScan_DoublePoint(ScanOperation scanOperation)
        {
            if (_instCtrl == null) return false;
            _currentScanOperation = scanOperation;
            _staThread.Invoke(new NoReturnAndParamDelegate(() =>
            {
                _instCtrl.PerformScan_DoublePoint();
            }), null);
            return true;
        }

        public bool PerformScan_DoublePointArray(ScanOperation scanOperation)
        {
            if (_instCtrl == null) return false;
            _currentScanOperation = scanOperation;
            _staThread.Invoke(new NoReturnAndParamDelegate(() =>
            {
                _instCtrl.PerformScan_DoublePointArray();
            }), null);
            return true;
        }
    }
}

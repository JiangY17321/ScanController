namespace FinchFlowController
{
    public interface IInstctrlScanCallBack
    {
        void ScanCompelete();

        void ScanFailed();

        /// <summary>
        /// auto-get the data from InstCtrl 
        /// </summary>
        void DataReceived_AutoGet();

        void DataReceived_SinglePoint(double value);

        void DataReceived_DoublePoint(double xValue, double yValue);

        void DataReceived_DoublePoint_Arrays(double[] xValues, double[] yValues);
    }
}

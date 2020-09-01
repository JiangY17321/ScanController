using FlowController;
using System.Collections.Generic;

namespace FinchFlowController
{
    public class FinchScanOperation:ScanOperation
    {
        private List<double> dataList;
        public FinchScanOperation()
        {
            dataList = new List<double>();
        }

        public override bool Run()
        {
            System.Diagnostics.Debug.WriteLine("FinchScanOperation Start Data collection");
            InstCtrlWrapper.GetInstance().PerformScan_SinglePoint(this);
            return true;
        }

        public override void ScanCompelete()
        {
            System.Diagnostics.Debug.WriteLine("ScanCompelete!");
            Sample sample = CreateSampleScanResult(new ScannedData(dataList));
            ScanFinished(sample);
        }

        public override void ScanFailed(int errorNum)
        {
            System.Diagnostics.Debug.WriteLine("ScanFailed!!!");
        }

        public override void DataReceived_SinglePoint(double value)
        {
            System.Diagnostics.Debug.WriteLine("SinglePoint:"+value);
            dataList.Add(value);
        }
    }
}

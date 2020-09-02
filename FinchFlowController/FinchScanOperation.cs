using FlowController;
using System.Collections.Generic;

namespace FinchFlowController
{
    public class FinchScanOperation:ScanOperation
    {
        private List<double> dataList;
        private List<double> xvalueList;
        private List<double> yvalueList;
        public FinchScanOperation()
        {
            dataList = new List<double>();
            xvalueList = new List<double>();
            yvalueList = new List<double>();
        }

        public override bool Run()
        {
            System.Diagnostics.Debug.WriteLine("FinchScanOperation Start Data collection");
            //InstCtrlWrapper.GetInstance().PerformScan_SinglePoint(this);
            InstCtrlWrapper.GetInstance().PerformScan_DoublePoint(this);
            return true;
        }

        public override void ScanCompelete()
        {
            System.Diagnostics.Debug.WriteLine("ScanCompelete!");
            //Sample sample = CreateSampleScanResult(new ScannedData(dataList));
            Sample sample = CreateSampleScanResult(new ScannedData(xvalueList, yvalueList));
            HandOverSampleToParent(sample);
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

        public override void DataReceived_DoublePoint(double xValue, double yValue)
        {
            System.Diagnostics.Debug.WriteLine("DoublePoint:" + xValue + "," + yValue);
            xvalueList.Add(xValue);
            yvalueList.Add(yValue);
        }
    }
}

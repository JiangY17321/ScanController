using FlowController;
using System.Collections.Generic;

namespace FinchFlowController
{
    public class FinchScanOperation:ScanOperation
    {
        private class TwoDimData
        {
            public List<double> xvalueList;
            public List<double> yvalueList;
        }

        private List<double> _oneDimData;
        private TwoDimData _twoDimData;
        private List<TwoDimData> _ThreeDimData;

        public FinchScanOperation()
        {
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
            Sample sample = null;
            if(_oneDimData!=null)
            {
                sample = CreateSampleScanResult(new ScannedData(_oneDimData));
            }
            else if(_twoDimData!=null)
            {
                sample = CreateSampleScanResult(new ScannedData(
                    _twoDimData.xvalueList, _twoDimData.yvalueList));
            }
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
            if(_oneDimData==null)
            {
                _oneDimData = new List<double>();
            }
            _oneDimData.Add(value);
        }

        public override void DataReceived_DoublePoint(double xValue, double yValue)
        {
            System.Diagnostics.Debug.WriteLine("DoublePoint:" + xValue + "," + yValue);
            if(_twoDimData==null)
            {
                _twoDimData = new TwoDimData();
            }
            _twoDimData.xvalueList.Add(xValue);
            _twoDimData.yvalueList.Add(yValue);
        }
    }
}

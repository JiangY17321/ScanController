namespace FlowController
{
    /// <summary>
    /// This opeartion sends the scan command to instrument.
    /// </summary>
    public abstract class ScanOperation : Operation
    {
        public ScanOperation() : base(OperationType.Scan)
        {

        }


        public virtual void ScanCompelete()
        {

        }

        public virtual void ScanFailed(int errorNum)
        {

        }

        public virtual void ScanAbort()
        {

        }
        public virtual void ScanHalted()
        {

        }


        /// <summary>
        /// auto-get the data from InstCtrl 
        /// </summary>
        public virtual void DataReceived_AutoGet()
        {

        }

        public virtual void DataReceived_SinglePoint(double value)
        {

        }

        public virtual void DataReceived_DoublePoint(double xValue, double yValue)
        {

        }

        public virtual void DataReceived_DoublePoint_Arrays(double[] xValues, double[] yValues)
        {

        }

        public Sample CreateSampleScanResult(ScannedData scannedData)
        {
            SampleOperation sampleOperation = GetParentOperationByType(typeof(SampleOperation)) as SampleOperation;
            if (sampleOperation != null)
            {
                SampleCurve sampleCurve = new SampleCurve();
                sampleCurve.CurveName = sampleOperation.Name;
                sampleCurve.SampleCurveData = new DimensionDataPoint(scannedData);

                Sample sample = new Sample();
                sample.SampleName= sampleOperation.Name;
                sample.AddCurve(sampleCurve);
                return sample;
            }
            return null;
        }

        public Sample CreateSampleScanResult(DimensionDataPoint dimensionDataPoint)
        {
            SampleOperation sampleOperation = GetParentOperationByType(typeof(SampleOperation)) as SampleOperation;
            if (sampleOperation != null)
            {
                SampleCurve sampleCurve = new SampleCurve();
                sampleCurve.CurveName = sampleOperation.Name;
                sampleCurve.SampleCurveData = dimensionDataPoint;

                Sample sample = new Sample();
                sample.SampleName = sampleOperation.Name;
                sample.AddCurve(sampleCurve);
                return sample;
            }
            return null;
        }

        protected void ScanFinished(Sample sample)
        {
            HandOverSampleToParent(sample);
            RunFinished();

        }
    }
}

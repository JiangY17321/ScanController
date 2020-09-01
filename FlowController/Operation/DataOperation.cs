using System.Collections.Generic;

namespace FlowController
{
    /// <summary>
    /// This operation will save the spectrum data for all the samples which 
    /// are children of this operation. The spectrum data will be joined together
    /// by the sample name.
    /// </summary>
    public class DataOperation : Operation
    {
        public Dictionary<string, Sample> sampleResultData { get; private set; }
        public DataOperation() : base(OperationType.Data)
        {
            sampleResultData = new Dictionary<string, Sample>();
        }

        protected override void ProcessSampleBeforeHandingOver(Sample sample)
        {
            if (sample == null) return;
            if(sampleResultData.ContainsKey(sample.SampleName)==false)
            {
                sampleResultData.Add(sample.SampleName, sample);
            }
        }

        public List<SampleCurve> GetSampleCurves(string sampleName)
        {
            if (sampleName == null) return null;
            if(sampleResultData.ContainsKey(sampleName))
            {
                Sample sample = sampleResultData[sampleName];
                return sample.GetCurves();
            }
            return null;
        }
    }
}

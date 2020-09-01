using System.Collections.Generic;

namespace FlowController
{
    public class Sample
    {
        public string SampleName { get; set; }

        private List<SampleCurve> _curves;

        public void AddCurve(SampleCurve sampleCurve)
        {
            if(_curves!=null)
            {
                foreach (SampleCurve curve in _curves)
                {
                    if (curve.CurveName.Equals(sampleCurve.CurveName))
                    {
                        return;
                    }
                }
            }
            else
            {
                _curves = new List<SampleCurve>();
            }
            _curves.Add(sampleCurve);
        }

        public List<SampleCurve> GetCurves()
        {
            List<SampleCurve> sampleCurves = new List<SampleCurve>();
            sampleCurves.AddRange(_curves);
            return sampleCurves;
        }
    }
}

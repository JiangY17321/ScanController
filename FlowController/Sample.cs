﻿using System.Collections.Generic;

namespace FlowController
{
    public class Sample
    {
        public string SampleName { get; set; }

        private List<SampleCurve> _curves;

        private List<GroupParam> _groupParams;

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
            sampleCurve.ParentSample = this;
            _curves.Add(sampleCurve);
        }

        public List<SampleCurve> GetCurves()
        {
            List<SampleCurve> sampleCurves = new List<SampleCurve>();
            sampleCurves.AddRange(_curves);
            return sampleCurves;
        }

        public void AddGroupParamToFront(GroupParam groupParam)
        {
            if(_groupParams==null)
            {
                _groupParams = new List<GroupParam>();
            }
            _groupParams.Insert(0,groupParam);
        }

        public bool IsGroupParamsEqual(Sample otherSample,List<GroupParam> differnetParam)
        {
            if (otherSample == null) return false;
            if (otherSample._groupParams.Count != _groupParams.Count) return false;
            bool ret = true;
            for(int i=0;i< _groupParams.Count;i++)
            {
                if(_groupParams[i].Equals(otherSample._groupParams[i])==false)
                {
                    ret= false;
                    if(differnetParam!=null && _groupParams[i].ParamName.Equals(otherSample._groupParams[i].ParamName))
                    {
                        differnetParam.Add(_groupParams[i]);
                    }
                }
            }
            return ret;
        }

        public SampleCurve GetSampleCurveByName(string curveName)
        {
            foreach (SampleCurve sampleCurve in _curves)
            {
                if(sampleCurve.CurveName.Equals(curveName))
                {
                    return sampleCurve;
                }
            }
            return null;
        }

        public void CombineDimensionData(Sample otherSample, List<GroupParam> groupParams)
        {
            if (otherSample == null || groupParams == null) return;
            if (groupParams.Count == 0) return;
            foreach(SampleCurve sampleCurve in  _curves)
            {
                SampleCurve otherCurve = otherSample.GetSampleCurveByName(sampleCurve.CurveName);
                if (otherCurve == null) continue;
                sampleCurve.CombineDimensionData(otherCurve, groupParams);
            }
        }

        public GroupParam GetGroupParamByName(string paramName)
        {
            foreach(GroupParam groupParam in _groupParams)
            {
                if (groupParam.ParamName.Equals(paramName))
                    return groupParam;
            }
            return null;
        }

        public void SetGroupParam()
        {
            foreach(SampleCurve sampleCurve in _curves)
            {
                sampleCurve.SampleCurveData.AddGroupParams(_groupParams);
            }
        }
    }
}

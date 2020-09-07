using System.Collections.Generic;

namespace FlowController
{
    public class SampleCurve
    {
        public Sample ParentSample { get; set; }
        public string CurveName { get; set; }

        public DimensionDataPoint SampleCurveData { get; set; }

        public void CombineDimensionData(SampleCurve otherCurve, List<GroupParam> groupParams)
        {
            if (otherCurve == null || groupParams == null) return;
            if (SampleCurveData == null || groupParams.Count==0) return;

            DimensionDataPoint otherCurveData = otherCurve.SampleCurveData;
            otherCurveData.AddGroupParams(groupParams);


            DimensionDataPoint last = null;
            DimensionDataPoint current = SampleCurveData;
            while (current != null)
            {
                if (current.IsGroupParamTypeEqual(groupParams))
                {
                    if (last != null)
                    {
                        last.DimensionDataList.Add(otherCurveData);
                        return;
                    }
                    else
                    {
                        DimensionDataPoint newList = new DimensionDataPoint();
                        newList.DimensionDataList.Add(SampleCurveData);
                        newList.DimensionDataList.Add(otherCurveData);
                        SampleCurveData = newList;
                        return;
                    }
                }
                else
                {
                    last = current;
                    if (current.IsScannedData)
                    {
                        current = null;
                    }
                    else
                    {
                        current = current.DimensionDataList[0];
                    }
                }
            }
        }
    }
}

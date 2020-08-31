using System.Collections.Generic;

namespace FlowController
{
    public enum Dimension
    {
        ONE,
        TWO,
    }
    public class ScannedData
    {
        public Dimension Dimension { get; set; }
        public List<double> dim1Data;
        public List<double> dim2Data;

        public ScannedData(List<double> dataList)
        {
            Dimension = Dimension.ONE;
            dim1Data = new List<double>();
            dim1Data.AddRange(dataList);

            dim2Data = null;
        }
        public ScannedData(List<double> dim1DataList, List<double> dim2DataList)
        {
            Dimension = Dimension.TWO;
            dim1Data = new List<double>();
            dim1Data.AddRange(dim1DataList);

            dim2Data = new List<double>();
            dim2Data.AddRange(dim2DataList);
        }

    }
}

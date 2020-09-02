using System.Collections.Generic;

namespace FlowController
{
    public class DimensionDataPoint
    {
        public double Value { get; set; }

        /// <summary>
        /// if ScannedData is null, the value is stored in DimensionDataList
        /// </summary>
        public ScannedData ScannedData { get; set; }
        public List<DimensionDataPoint> DimensionDataList { get; private set; }

        public DimensionDataPoint(ScannedData scannedData)
        {
            ScannedData = scannedData;
            DimensionDataList = null;

            if(scannedData==null)
            {
                DimensionDataList = new List<DimensionDataPoint>();
            }
        }
    }
}

namespace SimInstCtrl
{
    public class InstCtrl
    {
        public delegate void ScanCompelete();
        public delegate void ScanFailed();
        /// <summary>
        /// auto-get the data from InstCtrl 
        /// </summary>
        public delegate void DataReceived_AutoGet();

        public delegate void DataReceived_SinglePoint(double value);

        public delegate void DataReceived_SinglePoint_WithIndex(int index,double yValue);

        public delegate void DataReceived_DoublePoint(double xValue,double yValue);

        public delegate void DataReceived_DoublePoint_Arrays(double[] xValues, double[] yValues);


        public ScanCompelete ScanCompelete_CallBack { get; set; }

        public ScanFailed ScanFailed_CallBack { get; set; }

        public DataReceived_AutoGet AutoGet_CallBack { get; set; }

        public DataReceived_SinglePoint SinglePoint_CallBack { get; set; }

        public DataReceived_SinglePoint_WithIndex SinglePoint_WithIndex_CallBack { get; set; }

        public DataReceived_DoublePoint DoublePoint_CallBack { get; set; }

        public DataReceived_DoublePoint_Arrays DoublePoint_Arrays_CallBack { get; set; }
    }


}

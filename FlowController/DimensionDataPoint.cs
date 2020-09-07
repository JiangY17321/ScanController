using System.Collections.Generic;

namespace FlowController
{
    public class DimensionDataPoint
    {
        /// <summary>
        /// if ScannedData is null, the value is stored in DimensionDataList
        public ScannedData ScannedData { get; set; }

        //This variable only exists when ScannedData is null
        public List<DimensionDataPoint> DimensionDataList { get; private set; }

        /// <summary>
        /// Mostly GroupParams contains only one element,for instance, Temperature=20.
        /// But maybe temperature 20, pressure 100 combines as an added dimension (not common)
        /// </summary>
        private List<GroupParam> _groupParams;

        public bool IsScannedData
        {
            get
            {
                return ScannedData != null;
            }
        }

        public DimensionDataPoint()
        {
            ScannedData = null;
            DimensionDataList = new List<DimensionDataPoint>();
            _groupParams = new List<GroupParam>();
        }

        public void AddGroupParam(string paramName,double paramValue)
        {
            if(_groupParams==null)
            {
                _groupParams = new List<GroupParam>();
            }
            foreach(GroupParam groupParam in  _groupParams)
            {
                if(groupParam.ParamName.Equals(paramName))
                {
                    groupParam.ParamValue = paramValue;
                }
                return;
            }
            _groupParams.Add(new GroupParam(paramName, paramValue));
        }

        public void AddGroupParams(List<GroupParam> groupParams)
        {
            if (groupParams == null) return;
            foreach (GroupParam groupParam in groupParams)
            {
                AddGroupParam(groupParam.ParamName, groupParam.ParamValue);
            }
        }

        public string GetParamValueString()
        {
            string ret = null;
            foreach(GroupParam groupParam in _groupParams)
            {
                if(ret!=null)
                {
                    ret += ";";
                }
                ret += groupParam.ParamValue;
            }
            return ret;
        }

        public string GetParamValueName()
        {
            string ret = null;
            foreach (GroupParam groupParam in _groupParams)
            {
                if (ret != null)
                {
                    ret += ";";
                }
                ret += groupParam.ParamName;
            }
            return ret;
        }

        public bool IsGroupParamTypeEqual(List<GroupParam> groupParams)
        {
            if (_groupParams.Count != groupParams.Count) return false;
            for(int i=0;i< _groupParams.Count;i++)
            {
                if (_groupParams[i].ParamName.Equals(groupParams[i].ParamName) == false) return false;
            }
            return true;
        }
    }
}

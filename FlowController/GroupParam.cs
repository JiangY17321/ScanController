namespace FlowController
{
    public class GroupParam
    {
        public string ParamName { get; set; }
        public double ParamValue { get; set; }

        public GroupParam(string paramName,double paramValue)
        {
            ParamName = paramName;
            ParamValue = paramValue;
        }

        public override bool Equals(object obj)
        {
            if (obj as GroupParam == null) return false;
            GroupParam otherGroupParam = obj as GroupParam;
            return ParamName.Equals(otherGroupParam.ParamName) && ParamValue == otherGroupParam.ParamValue;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}

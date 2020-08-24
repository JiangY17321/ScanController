namespace FlowController
{
    public class TimeOperation : Operation
    {
        public string TimeName { get; set; }
        public TimeOperation() : base(OperationType.Time)
        {

        }
    }
}

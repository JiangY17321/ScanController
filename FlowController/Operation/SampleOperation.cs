namespace FlowController
{
    public class SampleOperation : Operation
    {
        public string SampleName { get; set; }
        public SampleOperation() : base(OperationType.Sample)
        {

        }
    }
}

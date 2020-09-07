namespace FlowController
{
    public class TemperatureOperation: Operation
    {
        [Export]
        public double Temperature { get; set; }
        public TemperatureOperation() : base(OperationType.Temperature)
        {

        }

        protected override void ProcessSampleBeforeHandingOver(Sample sample)
        {
            if (sample == null) return;
            sample.AddGroupParamToFront(new GroupParam("temperature", Temperature));
        }
    }
}

namespace FlowController
{
    public class TemperatureOperation: Operation
    {
        public string TemperatureName { get; set; }
        public TemperatureOperation() : base(OperationType.Temperature)
        {

        }
    }
}

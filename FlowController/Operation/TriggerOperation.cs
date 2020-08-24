namespace FlowController
{
    /// <summary>
    /// This operation just waits for the trigger and block.
    /// </summary>
    public class TriggerOperation : Operation
    {
        public string TriggerName { get; set; }
        public TriggerOperation() : base(OperationType.Trigger)
        {

        }
    }
}

namespace FlowController
{
    /// <summary>
    /// This operation just waits for the trigger and block.
    /// </summary>
    public class TriggerOperation : Operation
    {
        public TriggerOperation() : base(OperationType.Trigger)
        {

        }
    }
}

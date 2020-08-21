namespace FlowController
{
    /// <summary>
    /// This opeartion sends the scan command to instrument.
    /// </summary>
    public abstract class ScanOperation : Operation
    {
        public ScanOperation() : base(OperationType.Scan)
        {

        }
    }
}

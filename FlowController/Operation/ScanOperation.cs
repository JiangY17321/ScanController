namespace FlowController
{
    /// <summary>
    /// This opeartion sends the scan command to instrument.
    /// </summary>
    public abstract class ScanOperation : Operation
    {
        public string ScanName { get; set; }
        public ScanOperation() : base(OperationType.Scan)
        {

        }
    }
}

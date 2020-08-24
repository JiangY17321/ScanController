namespace FlowController
{
    /// <summary>
    /// Used for setting position of micro plate reader
    /// </summary>
    public class MPROperation : Operation
    {
        public string MPRName { get; set; }
        public MPROperation() : base(OperationType.MicroplateReader_Position)
        {

        }
    }
}

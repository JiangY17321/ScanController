namespace FlowController
{
    /// <summary>
    /// This operation will save the spectrum data for all the samples which 
    /// are children of this operation. The spectrum data will be joined together
    /// by the sample name.
    /// </summary>
    public class DataOperation : Operation
    {
        public string DataName { get; set; }

        public DataOperation() : base(OperationType.Data)
        {

        }
    }
}

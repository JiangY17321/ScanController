namespace FlowController
{
    /// <summary>
    /// The same as DataOperation except this operation is about background collection
    /// </summary>
    public class BackgroundDataOperation : Operation
    {
        public string BackgroundDataName { get; set; }
        public BackgroundDataOperation() : base(OperationType.BackgroundData)
        {

        }
    }
}

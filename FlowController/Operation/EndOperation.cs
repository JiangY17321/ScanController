namespace FlowController
{
    /// <summary>
    /// When every opreation in an experiment has finished, this operation is called
    /// </summary>
    public class EndOperation : Operation
    {
        public EndOperation() : base(OperationType.End)
        {

        }
    }
}

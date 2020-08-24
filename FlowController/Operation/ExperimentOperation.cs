namespace FlowController
{
    /// <summary>
    /// The root node of an opreation tree
    /// </summary>
    public class ExperimentOperation:Operation
    {
        public string ExperimentName { get; set; }
        public ExperimentOperation() : base(OperationType.Experiment)
        {

        }
    }
}

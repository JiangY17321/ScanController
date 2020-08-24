using FlowController;

namespace TestWinLab
{
    public class ExperimentOperationNode:OperationNode
    {
        public override string Content
        {
            get
            {
                if ((Operation as ExperimentOperation) != null)
                {
                    return (Operation as ExperimentOperation).ExperimentName;
                }
                return content;
            }
            set
            {
                content = value;
                if ((Operation as ExperimentOperation) != null)
                {
                    (Operation as ExperimentOperation).ExperimentName = value;
                }
                OnPropertyChanged("Content");
            }
        }
        public ExperimentOperationNode(string content)
        {
            ParentNode = null;
            Operation = null;
            Content = content;
            Operation = new ExperimentOperation();
            (Operation as ExperimentOperation).ExperimentName = content;
        }
    }
}

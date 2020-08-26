using FlowController;

namespace TestWinLab
{
    public class TemperatureOperationNode : OperationNode
    {
        public override string Content
        {
            get
            {
                if (TemperatureOperation != null)
                    return TemperatureOperation.Name;
                return content;
            }
            set
            {
                content = value;
                if (TemperatureOperation != null)
                    TemperatureOperation.Name = value;
                OnPropertyChanged("Content");
            }
        }

        public TemperatureOperation TemperatureOperation
        {
            get
            {
                return Operation as TemperatureOperation;
            }
        }


        public TemperatureOperationNode(string content)
        {
            ParentNode = null;
            Operation = null;
            Content = content;
            Operation = new TemperatureOperation();
            TemperatureOperation.Name = content;
        }

        public TemperatureOperationNode(TemperatureOperation temperatureOperation)
        {
            Operation = temperatureOperation;
            ParentNode = null;
        }
    }
}

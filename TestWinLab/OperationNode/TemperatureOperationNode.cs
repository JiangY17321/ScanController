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
                    return TemperatureOperation.TemperatureName;
                return content;
            }
            set
            {
                content = value;
                if (TemperatureOperation != null)
                    TemperatureOperation.TemperatureName = value;
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
            TemperatureOperation.TemperatureName = content;
        }

        public TemperatureOperationNode(TemperatureOperation temperatureOperation)
        {
            Operation = temperatureOperation;
            ParentNode = null;
        }
    }
}

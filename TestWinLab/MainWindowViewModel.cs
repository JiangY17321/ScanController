using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace TestWinLab
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<OperationNode> operationNodes = new ObservableCollection<OperationNode>();
        public ObservableCollection<OperationNode> OperationNodes
        {
            get { return operationNodes; }
            set
            {
                operationNodes = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("OperationNodes"));
            }
        }

        public ICommand CreateOperationCommand { get; }

        public MainWindowViewModel()
        {
            operationNodes = new ObservableCollection<OperationNode>();
            CreateOperationCommand = new RelayCommand(CanCreateOperation, CreateOperation);
        }

        private void CreateOperation(object param)
        {
            if (param == null) return;
            OperationNode currentNode = GetCurrentNode(operationNodes);
            if (currentNode == null && operationNodes.Count!=0)
            {
                currentNode = operationNodes[0];
            }

            OperationNode newOpeartionNode = null;
            switch (param.ToString())
            {
                case "experiment":
                    CreateExperimentNode();
                    break;
                case "general_Param":
                    newOpeartionNode = new GeneralParamOperationNode("General Param");
                    break;
                case "data":
                    newOpeartionNode = new DataOperationNode("Data");
                    break;
                case "background_data":
                    newOpeartionNode = new BackgroundDataOperationNode("Background Data");
                    break;
                case "sample":
                    newOpeartionNode = new SampleOperationNode("Sample");
                    break;
                case "scan":
                    newOpeartionNode = new ScanOperationNode("Scan");
                    break;
                case "trigger":
                    newOpeartionNode = new TriggerOperationNode("Trigger");
                    break;
                case "temperature":
                    newOpeartionNode = new TemperatureOperationNode("Temperature");
                    break;
                case "time":
                    newOpeartionNode = new TimeOperationNode("Time");
                    break;
                case "microplatereader":
                    newOpeartionNode=new MPROperationNode("Microplate Reader");
                    break;
                case "wavelength":
                    newOpeartionNode = new WaveLengthOperationNode("Wave Length");
                    break;
            }

            if(newOpeartionNode!=null)
            {
                currentNode.Children.Add(newOpeartionNode);
                newOpeartionNode.ParentNode = currentNode;
                currentNode.IsExpanded = true;
                newOpeartionNode.IsSelected = true;
            }
        }

        private bool CanCreateOperation(object param)
        {
            switch (param.ToString())
            {
                case "general_Param":
                case "data":
                case "background_data":
                case "sample":
                case "scan":
                case "trigger":
                case "temperature":
                case "time":
                case "microplatereader":
                case "wavelength":
                    if (operationNodes.Count == 0) return false;
                    break;
            }
            return true;
        }

        private void CreateExperimentNode()
        {
            operationNodes.Add(new ExperimentOperationNode("Experiment"));
        }

        private OperationNode GetCurrentNode(IList<OperationNode> operationNodeList)
        {
            foreach(OperationNode node in operationNodeList)
            {
                if (node.IsSelected) return node;
                OperationNode selectedNode= GetCurrentNode(node.Children);
                if (selectedNode !=null) return selectedNode;
            }
            return null;
        }

        public void DeleteCurrentNode()
        {
            OperationNode currentNode = GetCurrentNode(operationNodes);
            if (currentNode == null) return;
            if (currentNode.ParentNode == null) return;
            if(currentNode.ParentNode.Children.Contains(currentNode))
            {
                currentNode.ParentNode.Children.Remove(currentNode);
            }
        }
    }
}

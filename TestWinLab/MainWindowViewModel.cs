using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using FlowController;

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
            switch(param.ToString())
            {
                case "experiment":
                    CreateExperimentNode();
                    break;
                case "general_Param":
                    CreateSubNode("General Param",new GeneralParamOperation());
                    break;
                case "data":
                    CreateSubNode("Data", new DataOperation());
                    break;
                case "background_data":
                    CreateSubNode("Background Data", new BackgroundDataOperation());
                    break;
                case "sample":
                    CreateSubNode("Sample", new SampleOperation());
                    break;
                case "scan":
                    CreateSubNode("Scan", new ScanOperation());
                    break;
                case "trigger":
                    CreateSubNode("Trigger", new TriggerOperation());
                    break;
                case "temperature":
                    CreateSubNode("Temperature", new TemperatureOperation());
                    break;
                case "time":
                    CreateSubNode("Time", new TimeOperation());
                    break;
                case "microplatereader":
                    CreateSubNode("Microplate Reader", new MPROperation());
                    break;
                case "wavelength":
                    CreateSubNode("Wave Length", new WaveLengthOperation());
                    break;
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
            operationNodes.Add(new OperationNode()
            {
                Content = "Experiment",
                Operation = new ExperimentOperation(),
            });
        }

        private void CreateSubNode(string content,Operation operation)
        {
            OperationNode currentNode = GetCurrentNode(operationNodes);
            if (currentNode == null)
            {
                currentNode = operationNodes[0];
            }
            OperationNode opeartionNode = new OperationNode()
            {
                Content = content,
                Operation = operation
            };
            currentNode.Children.Add(opeartionNode);
            opeartionNode.ParentNode = currentNode;
            currentNode.IsExpanded = true;
            opeartionNode.IsSelected = true;
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

using FinchFlowController;
using FlowController;
using SimInstCtrl;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading;
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

        public ICommand RunCommand { get; }


        public MainWindowViewModel()
        {
            operationNodes = new ObservableCollection<OperationNode>();
            CreateOperationCommand = new RelayCommand(CanCreateOperation, CreateOperation);
            RunCommand= new RelayCommand(CanRun, Run);
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
                    newOpeartionNode = new FastScanParamOperationNode("FastScan Param");
                    break;
                case "data":
                    newOpeartionNode = new DataOperationNode("Data");
                    break;
                case "background_data":
                    newOpeartionNode = new BackgroundDataOperationNode("Background Data");
                    break;
                case "sample":
                    newOpeartionNode = new SampleOperationNode("Administrator 01");
                    break;
                case "scan":
                    newOpeartionNode = new FinchScanOperationNode("Scan");
                    break;
                case "trigger":
                    newOpeartionNode = new TriggerOperationNode("Trigger");
                    break;
                case "temperature":
                    newOpeartionNode = new TemperatureOperationNode("Peltier");
                    break;
                case "temperatureScan":
                    newOpeartionNode = new PeltierScanOperationNode("PeltierScan");
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
                case "temperatureScan":
                    if (operationNodes.Count == 0) return false;
                    break;
            }
            return true;
        }


        private void Run(object param)
        {
            List<Operation> opeartionList = new List<Operation>();
            foreach(OperationNode operationNode in operationNodes)
            {
                Operation operation= GenerateOperationTree(operationNode);
                if(operation!=null)
                {
                    opeartionList.Add(operation);
                }
            }

            Thread thread = new Thread(() =>
              {
                  foreach(Operation experimentOperation in opeartionList)
                  {
                      if(experimentOperation is ExperimentOperation)
                      {
                          ExperimentFlow.GetInstance().RunNewExperiment(experimentOperation as ExperimentOperation);
                      }
                  }
              }){ IsBackground = true };
            thread.Start();
        }

        private bool CanRun(object param)
        {
            if (operationNodes.Count == 0) return false;
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

        private Operation GenerateOperationTree(OperationNode rootOpeartionNode)
        {
            if (rootOpeartionNode == null) return null;
            if (rootOpeartionNode.Operation == null) return null;
            if (rootOpeartionNode.Operation.ChildOperations == null) return null;
            rootOpeartionNode.Operation.ChildOperations.Clear();
            foreach (OperationNode operationNode in rootOpeartionNode.Children)
            {
                if(operationNode.Operation!=null)
                {
                    rootOpeartionNode.Operation.ChildOperations.Add(operationNode.Operation);
                }
                GenerateOperationTree(operationNode);
            }
            return rootOpeartionNode.Operation;
        }

        public OperationNode GenerateOperationNodeTree(Operation operation)
        {
            if (operation == null) return null;
            OperationNode operationNode = null;
            if(operation.GetType()== typeof(BackgroundDataOperation))
            {
                operationNode = new BackgroundDataOperationNode(operation as BackgroundDataOperation);
            }
            else if (operation.GetType() == typeof(DataOperation))
            {
                operationNode = new DataOperationNode(operation as DataOperation);
            }
            else if (operation.GetType() == typeof(ExperimentOperation))
            {
                operationNode = new ExperimentOperationNode(operation as ExperimentOperation);
            }
            else if (operation.GetType() == typeof(FastScanParamOperation))
            {
                operationNode = new FastScanParamOperationNode(operation as FastScanParamOperation);
            }
            else if (operation.GetType() == typeof(MPROperation))
            {
                operationNode = new MPROperationNode(operation as MPROperation);
            }
            else if (operation.GetType() == typeof(SampleOperation))
            {
                operationNode = new SampleOperationNode(operation as SampleOperation);
            }
            else if (operation.GetType() == typeof(TemperatureOperation))
            {
                operationNode = new TemperatureOperationNode(operation as TemperatureOperation);
            }
            else if (operation.GetType() == typeof(TimeOperation))
            {
                operationNode = new TimeOperationNode(operation as TimeOperation);
            }
            else if (operation.GetType() == typeof(TriggerOperation))
            {
                operationNode = new TriggerOperationNode(operation as TriggerOperation);
            }
            else if (operation.GetType() == typeof(WaveLengthOperation))
            {
                operationNode = new WaveLengthOperationNode(operation as WaveLengthOperation);
            }
            else if (operation.GetType() == typeof(FinchScanOperation))
            {
                operationNode = new FinchScanOperationNode(operation as FinchScanOperation);
            }
            else if (operation.GetType() == typeof(PeltierScanOperation))
            {
                operationNode = new PeltierScanOperationNode(operation as PeltierScanOperation);
            }
            foreach (Operation childOperation in operation.ChildOperations)
            {
                OperationNode childOperationNode = GenerateOperationNodeTree(childOperation);
                if(childOperationNode!=null && operationNode != null)
                {
                    operationNode.Children.Add(childOperationNode);
                }
            }
            return operationNode;
        }

        public void SaveOperationTreeToFile(string fileName)
        {
            if (operationNodes.Count == 0) return;
            if (operationNodes[0] == null) return;
            Operation operation= GenerateOperationTree(operationNodes[0]);
            ExperimentOperation experimentOperation = operation as ExperimentOperation;

            if(experimentOperation!=null)
            {
                ExperimentFlow.GetInstance().SaveOperationTreeToFile(experimentOperation, fileName);
            }
        }

        public void OpenOperationTreeFile(string fileName)
        {
            ExperimentOperation experimentOperation = ExperimentFlow.GetInstance().LoadOperationTreeFromFile(fileName);
            if (experimentOperation == null) return;

            OperationNode opeartionNode = GenerateOperationNodeTree(experimentOperation);
            ExpandOperationNode(opeartionNode);
            if (opeartionNode as ExperimentOperationNode!=null)
            {
                operationNodes.Clear();
                operationNodes.Add(opeartionNode);
                opeartionNode.IsSelected = true;
            }
        }

        private void ExpandOperationNode(OperationNode opeartionNode)
        {
            if (opeartionNode == null) return;
            opeartionNode.IsExpanded = true;
            foreach(OperationNode node in opeartionNode.Children)
            {
                ExpandOperationNode(node);
            }
        }
    }
}

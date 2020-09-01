using FlowController;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TestWinLab
{
    public class DataOperationNode : OperationNode
    {
        public ObservableCollection<SampleEntry> SampleEntries { get; private set; }

        public override string Content
        {
            get
            {
                if (DataOperation != null)
                    return DataOperation.Name;
                return content;
            }
            set
            {
                content = value;
                if (DataOperation != null)
                    DataOperation.Name = value;
                OnPropertyChanged("Content");
            }
        }

        public DataOperation DataOperation
        {
            get
            {
                return Operation as DataOperation;
            }
        }

        public DataOperationNode(string content)
        {
            ParentNode = null;
            Operation = null;
            Content = content;
            Operation = new DataOperation();
            DataOperation.Name = content;
            SampleEntries = new ObservableCollection<SampleEntry>();
        }

        public DataOperationNode(DataOperation dataOperation)
        {
            Operation = dataOperation;
            ParentNode = null;
            SampleEntries = new ObservableCollection<SampleEntry>();
        }

        public void InitializingSampleEntries()
        {
            List<string> sampleEntries = new List<string>();
            GetSampleEntryNames(this, sampleEntries);
            SampleEntries.Clear();
            foreach(string sampleName in sampleEntries)
            {
                SampleEntry sampleEntry = new SampleEntry()
                {
                    SampleName = sampleName,
                };
                SampleEntries.Add(sampleEntry);
            }
        }

        private static void GetSampleEntryNames(OperationNode operationNode,
            List<string> sampleEntries)
        {
            if (operationNode == null) return;
            if (sampleEntries == null) return;
            foreach (OperationNode childNode in operationNode.Children)
            {
                if (childNode == null) continue;
                if(childNode is SampleOperationNode)
                {
                    string sampleName = (childNode as SampleOperationNode).Content;
                    if (sampleEntries.Contains(sampleName) == false)
                    {
                        sampleEntries.Add(sampleName);
                    }
                }
                GetSampleEntryNames(childNode, sampleEntries);
            }
        }
    }
}

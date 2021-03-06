﻿using FlowController;

namespace TestWinLab
{
    public class ExperimentOperationNode:OperationNode
    {
        public override string Content
        {
            get
            {
                if(ExperimentOperation!=null)
                    return ExperimentOperation.Name;
                return content;
            }
            set
            {
                content = value;
                if (ExperimentOperation != null)
                    ExperimentOperation.Name = value;
                OnPropertyChanged("Content");
            }
        }

        public ExperimentOperation ExperimentOperation
        {
            get
            {
                return Operation as ExperimentOperation;
            }
        }

        public ExperimentOperationNode(string content)
        {
            ParentNode = null;
            Operation = null;
            Content = content;
            Operation = new ExperimentOperation();
            ExperimentOperation.Name = content;
        }

        public ExperimentOperationNode(ExperimentOperation experimentOperation)
        {
            Operation = experimentOperation;
            ParentNode = null;
        }
    }
}

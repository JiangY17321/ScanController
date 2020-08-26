﻿using FlowController;

namespace TestWinLab
{
    public class DataOperationNode : OperationNode
    {
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
        }

        public DataOperationNode(DataOperation dataOperation)
        {
            Operation = dataOperation;
            ParentNode = null;
        }
    }
}

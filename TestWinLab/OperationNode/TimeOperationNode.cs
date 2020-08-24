﻿using FlowController;

namespace TestWinLab
{
    public class TimeOperationNode : OperationNode
    {
        public override string Content
        {
            get
            {
                if (TimeOperation != null)
                    return TimeOperation.TimeName;
                return content;
            }
            set
            {
                content = value;
                if (TimeOperation != null)
                    TimeOperation.TimeName = value;
                OnPropertyChanged("Content");
            }
        }

        public TimeOperation TimeOperation
        {
            get
            {
                return Operation as TimeOperation;
            }
        }

        public TimeOperationNode(string content)
        {
            ParentNode = null;
            Operation = null;
            Content = content;
            Operation = new TimeOperation();
            TimeOperation.TimeName = content;
        }

        public TimeOperationNode(TimeOperation timeOperation)
        {
            Operation = timeOperation;
            ParentNode = null;
        }
    }
}

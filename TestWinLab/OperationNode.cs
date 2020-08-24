using System.Collections.ObjectModel;
using System.ComponentModel;
using FlowController;

namespace TestWinLab
{
    public class OperationNode : INotifyPropertyChanged
    {
        private bool _isSelected;
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (_isSelected != value)
                {
                    _isSelected = value;
                    OnPropertyChanged("IsSelected");
                }
            }
        }

        private bool _isExpanded;
        public bool IsExpanded
        {
            get { return _isExpanded; }
            set
            {
                if (_isExpanded != value)
                {
                    _isExpanded = value;
                    OnPropertyChanged("IsExpanded");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public OperationNode()
        {
            Children = new ObservableCollection<OperationNode>();
            parentNode = null;
            operation = null;
            content = null;
        }

        protected string content;
        public virtual string Content
        {
            get
            {
                return content;
            }
            set
            {
                content = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Content"));
            }
        }

        private ObservableCollection<OperationNode> children;
        public ObservableCollection<OperationNode> Children
        {
            get
            {
                return children;
            }
            set
            {
                children = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Children"));
            }
        }

        private OperationNode parentNode;
        public OperationNode ParentNode
        {
            get
            {
                return parentNode;
            }
            set
            {
                parentNode = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ParentNode"));
            }
        }

        private Operation operation;
        public Operation Operation
        {
            get
            {
                return operation;
            }
            set
            {
                operation = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Operation"));
            }
        }
    }
}

using System.Collections.Generic;
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
            ParentNode = null;
        }

        private string _content;
        public string Content
        {
            get
            {
                return _content;
            }
            set
            {
                _content = value;
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

        public OperationNode ParentNode { get; set; }

        public Operation Operation { get; set; }
    }
}

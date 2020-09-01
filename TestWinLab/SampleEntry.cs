using System.ComponentModel;

namespace TestWinLab
{
    public class SampleEntry : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _sampleName;
        public string SampleName
        {
            get
            {
                return _sampleName;
            }
            set
            {
                _sampleName = value;
                OnPropertyChanged("SampleName");
            }
        }
    }
}

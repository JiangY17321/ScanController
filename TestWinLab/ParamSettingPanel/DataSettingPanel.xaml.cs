using System.Windows;
using System.Windows.Controls;

namespace TestWinLab.ParamSettingPanel
{
    /// <summary>
    /// Interaction logic for DataSettingPanel.xaml
    /// </summary>
    public partial class DataSettingPanel : UserControl
    {
        public DataSettingPanel()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            DataOperationNode dataOperationNode = dgSamples.DataContext as DataOperationNode;
            if(dataOperationNode!=null)
            {
                dataOperationNode.InitializingSampleEntries();
                dgSamples.ItemsSource = dataOperationNode.SampleEntries;
            }
        }
    }
}

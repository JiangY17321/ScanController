using FlowController;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using TestWinLab.ParamSettingPanel;

namespace TestWinLab
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel mainWindowViewModel = null;
        private Dictionary<OperationType, UserControl> paramSettingPanelDict = null;
        public MainWindow()
        {
            InitializeComponent();
            mainWindowViewModel = new MainWindowViewModel();
            paramSettingPanelDict = new Dictionary<OperationType, UserControl>();
            DataContext = mainWindowViewModel;
        }

        private void OperationTreeView_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if(e.Key==System.Windows.Input.Key.Delete)
            {
                mainWindowViewModel.DeleteCurrentNode();
            }
        }

        private void OperationTreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            TreeView treeview = sender as TreeView;
            if (treeview == null) return;
            OperationNode selectedItem = treeview.SelectedItem as OperationNode;
            if (selectedItem == null) return;
            if (selectedItem.Operation == null) return;

            UserControl paramSettingUserControl = null;

            if(paramSettingPanelDict.ContainsKey(selectedItem.Operation.OperationType))
            {
                paramSettingUserControl = paramSettingPanelDict[selectedItem.Operation.OperationType];
            }
            else
            {
                switch (selectedItem.Operation.OperationType)
                {
                    case OperationType.Experiment:
                        paramSettingUserControl = new ExperimentSettingPanel();
                        break;
                    case OperationType.GeneralParam:
                        paramSettingUserControl = new GeneralParamSettingPanel();
                        break;
                    case OperationType.Data:
                        paramSettingUserControl = new DataSettingPanel();
                        break;
                    case OperationType.BackgroundData:
                        paramSettingUserControl = new BackgroundDataSettingPanel();
                        break;
                    case OperationType.Sample:
                        paramSettingUserControl = new SampleSettingPanel();
                        break;
                    case OperationType.Scan:
                        paramSettingUserControl = new ScanSettingPanel();
                        break;
                    case OperationType.Trigger:
                        paramSettingUserControl = new TriggerSettingPanel();
                        break;
                    case OperationType.Time:
                        paramSettingUserControl = new TimeSettingPanel();
                        break;

                }
                paramSettingPanelDict.Add(selectedItem.Operation.OperationType, paramSettingUserControl);
            }

            if(paramSettingUserControl!=null)
            {
                tabItemParamSetting.Content = paramSettingUserControl;
                paramSettingUserControl.DataContext = selectedItem;
            }
        }
    }
}

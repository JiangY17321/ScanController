using FlowController;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace TestWinLab.ParamSettingPanel
{
    /// <summary>
    /// Interaction logic for DataSettingPanel.xaml
    /// </summary>
    public partial class DataSettingPanel : UserControl
    {
        private SampleEntry _lastSampleEntry;
        public DataSettingPanel()
        {
            InitializeComponent();
            _lastSampleEntry = null;
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

        private void DgSamples_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            SampleEntry sampleEntry = dgSamples.SelectedItem as SampleEntry;
            if (_lastSampleEntry == sampleEntry) return;
            if (sampleEntry == null) return;
            _lastSampleEntry = sampleEntry;
            DataOperationNode dataOperationNode = DataContext as DataOperationNode;
            if (dataOperationNode == null) return;
            if (dataOperationNode.DataOperation == null) return;
            string sampleName = sampleEntry.SampleName;
            List<SampleCurve> sampleCurves= dataOperationNode.DataOperation.GetSampleCurves(sampleName);
            if (sampleCurves == null) return;
            if (sampleCurves.Count == 0) return;
            ShowSampleCurve(sampleCurves[0]);
        }

        private void ShowSampleCurve(SampleCurve sampleCurve)
        {
            if (sampleCurve == null) return;
            DimensionDataPoint dimensionDataPoint = sampleCurve.SampleCurveData;
            ScannedData scannedData = dimensionDataPoint.ScannedData;
            if (scannedData == null) return;

            List<double> indexList = new List<double>();
            List<double> xAxisData = null;
            List<double> yAxisData = null;

            if (scannedData.dim2Data!=null)
            {
                indexList.AddRange(scannedData.dim2Data);
                xAxisData = scannedData.dim1Data;
                yAxisData = scannedData.dim2Data;
            }
            else
            {
                for (int i = 0; i < scannedData.dim1Data.Count; i++)
                {
                    indexList.Add(i + 1);
                }
                xAxisData = indexList;
                yAxisData = scannedData.dim1Data;
            }
            linegraph.Plot(xAxisData, yAxisData); // x and y are IEnumerable<double>
        }
    }
}

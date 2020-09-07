using FlowController;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public ObservableCollection<string> Z_DimValues { get; set; }

        private DimensionDataPoint _currrentDimensionDataPoint;


        public DataSettingPanel()
        {
            InitializeComponent();
            _lastSampleEntry = null;
            Z_DimValues = new ObservableCollection<string>();
            _currrentDimensionDataPoint = null;
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
            if(dimensionDataPoint.ScannedData!=null)
            {
                ScannedData scannedData = dimensionDataPoint.ScannedData;
                ShowScannnedData(scannedData);
            }
            else if(dimensionDataPoint.DimensionDataList!=null)
            {
                Z_DimValues.Clear();
                string paramName = null;
                for (int i=0;i< dimensionDataPoint.DimensionDataList.Count; i++)
                {
                    Z_DimValues.Add(dimensionDataPoint.DimensionDataList[i].GetParamValueString());
                    paramName = dimensionDataPoint.DimensionDataList[i].GetParamValueName();
                }
                if(paramName!=null)
                {
                    txtDimZ.Text = paramName;
                }
                cbDimZValue.ItemsSource = Z_DimValues;
                cbDimZValue.SelectedIndex = 0;
                _currrentDimensionDataPoint = dimensionDataPoint;
                CbDimZValue_SelectionChanged(null, null);
            }
        }

        private void ShowScannedData(DimensionDataPoint dimensionDataPoint,int index)
        {
            if (dimensionDataPoint == null) return;
            if (dimensionDataPoint.DimensionDataList == null) return;
            if (index < 0 || index >= dimensionDataPoint.DimensionDataList.Count) return;
            ShowScannnedData(dimensionDataPoint.DimensionDataList[index].ScannedData);
        }

        private void CbDimZValue_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ShowScannedData(_currrentDimensionDataPoint, cbDimZValue.SelectedIndex);
        }

        private void ShowScannnedData(ScannedData scannedData)
        {
            if (scannedData == null) return;

            List<double> indexList = new List<double>();
            List<double> xAxisData;
            List<double> yAxisData;
            if (scannedData.dim2Data != null)
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

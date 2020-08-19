using System;
using System.Globalization;
using System.Windows.Data;
using FlowController;

namespace TestWinLab
{
    internal class ImagePathConverter : IValueConverter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return null;
            Operation operation = value as Operation;
            if (operation == null) return null;
            switch (operation.OperationType)
            {
                case OperationType.Experiment:
                    return "Image/Experiment.png";
                case OperationType.GeneralParam:
                    return "Image/GeneralParam.png";
                case OperationType.Data:
                    return "Image/Data.png";
                case OperationType.BackgroundData:
                    return "Image/BackgroundData.png";
                case OperationType.Sample:
                    return "Image/Sample.png";
                case OperationType.Scan:
                    return "Image/Scan.png";
                case OperationType.Trigger:
                    return "Image/Trigger.png";
                case OperationType.Temperature:
                    return "Image/Temperature.png";
                case OperationType.Time:
                    return "Image/Time.png";
                case OperationType.MicroplateReader_Position:
                    return "Image/Microplatereader.png";
                case OperationType.WaveLength:
                    return "Image/Wavelength.png";
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}

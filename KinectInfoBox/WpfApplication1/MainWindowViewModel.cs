using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        private string connectionIDValue;
        public event PropertyChangedEventHandler PropertyChanged;
        
        public string ConnectionID
        {
            get
            {
                return this.connectionIDValue;
            }
            set
            {
                if (this.connectionIDValue != value)
                {
                    this.connectionIDValue = value;
                    this.OnNotifyPropertyChange("ConnectionID");
                }
            }
        }
        public void OnNotifyPropertyChange(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private ObservableCollection<ColorImageFormat> colorImageFormatvalue;
        public ObservableCollection<ColorImageFormat> ColorImageFormats
        {
            get
            {
                colorImageFormatvalue = new ObservableCollection<ColorImageFormat>();
                foreach (ColorImageFormat colorImageFormat in Enum.GetValues(typeof(ColorImageFormat)))
                {
                    colorImageFormatvalue.Add(colorImageFormat);
                }
                return colorImageFormatvalue;
            }
        }
        private ColorImageFormat CurrentImageFormatValue;
        public ColorImageFormat CurrentImageFormat
        {
            get
            {
                return this.CurrentImageFormatValue;
            }
            set
            {
                if (CurrentImageFormatValue != value)
                {
                    CurrentImageFormatValue = value;
                    this.OnNotifyPropertyChange("CurrentImageFormat");
                }
            }
        }
    }
}
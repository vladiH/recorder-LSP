using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Kinect;
using KinectStatusNotifier;

namespace WpfApplication1
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        KinectSensor sensor;      
        private MainWindowViewModel viewModel;
        private StatusNotifier notifier = new StatusNotifier();

        public MainWindow()
        {
            InitializeComponent();
            this.InitializeComponent();
            this.Loaded += this.MainWindow_Loaded;
            this.viewModel = new MainWindowViewModel();
            this.DataContext = this.viewModel;
        }
        private void SetKinectInfo()
        {
            if (this.sensor != null)
            {
                this.viewModel.ConnectionID = this.sensor.DeviceConnectionId;
                // Set other property values
            }
        }
        private void StartSensor()
        {
            if (this.sensor != null && !this.sensor.IsRunning)
            {
                KinectSensor sensor = KinectSensor.KinectSensors[0];
                this.sensor.Start();
                int position = 0;
                var collection = KinectSensor.KinectSensors.Where(item => item.DeviceConnectionId == sensor.DeviceConnectionId);
                var indexCollection = from item in collection
                                      let row = position++
                                      select new { SensorObject = item, SensorIndex = row };
                MostrarEstadoSensor();
            }
        }
        private void MostrarEstadoSensor(){
            txConnectID.Text = sensor.DeviceConnectionId;
                txUniqueDevice.Text = sensor.UniqueKinectId;
                txStatus.Text = sensor.Status.ToString();
                if (sensor.IsRunning) { txAngle.Text = sensor.ElevationAngle.ToString(); }
                else txAngle.Text = "0";
        }
        private void StopSensor()
        {
            if (this.sensor != null && this.sensor.IsRunning)
            {
                this.sensor.Stop();
            }
            MostrarEstadoSensor();
        }
        protected void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (KinectSensor.KinectSensors.Count > 0)
            {
                this.sensor = KinectSensor.KinectSensors[0];
                this.StartSensor();
                this.notifier.Sensors = KinectSensor.KinectSensors;
                //this.sensor.ColorStream.Enable();
               // this.sensor.DepthStream.Enable();
               // this.sensor.SkeletonStream.Enable();
                // visualizacion
                cbColor.IsChecked = true;
                cbDepth.IsChecked = true;
                cbSkeleton.IsChecked = true;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            StartSensor();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            StopSensor();
        }

        private void btnSensores_Click(object sender, RoutedEventArgs e)
        {
            rgb_depth_track s = new rgb_depth_track();
            s.Show();
           // MainWindowsDepthCam c = new MainWindowsDepthCam();
            //c.Show();
        }
    }
}

using System;
using System.Windows;
using NAudio.Wave;


namespace RadioPlayer
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private IWavePlayer outputDevice;
        private MediaFoundationReader reader;

        public MainWindow()
        {
            InitializeComponent();
        }
        private void Start_Click(object sender ,  RoutedEventArgs e)
        {
            try
            {
                StopAudio();

                string url = UrlBox.Text;

                reader = new MediaFoundationReader(url);

                outputDevice = new WaveOutEvent();

                outputDevice.Init(reader);
                outputDevice.Play();

                StatusText.Text = "Статус: играет";


            }

            catch(Exception ex)
            {
                StatusText.Text = "Ошибка: " + ex.Message;
            }
        }
        private void Stop_Click(object sender , RoutedEventArgs e)
        {
            StopAudio();
            StatusText.Text = "Статус: остановлено";
        }
        private void StopAudio()
        {
            outputDevice?.Stop();
            outputDevice?.Dispose();
            outputDevice = null;

            reader?.Dispose();
            reader = null;

        }
        protected override void OnClosed(EventArgs e)
        {
            StopAudio();
            base.OnClosed(e);
        }
    }
}

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
        
     }
}

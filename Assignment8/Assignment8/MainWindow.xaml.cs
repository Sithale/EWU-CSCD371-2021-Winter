using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace Assignment8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly DispatcherTimer dispatcherTimer = new();

        private DateTime _StartTime = DateTime.Now;
        private string _Description;
        private bool _IsStopped = true;
        private int Entry = 1;

        private void Description_TextChanged(object sender, TextChangedEventArgs e) => _Description = Description.Text;

        public MainWindow()
        {
            InitializeComponent();

            dispatcherTimer.Tick += new EventHandler(DispatcherTimer_Tick);
            dispatcherTimer.Interval = TimeSpan.FromSeconds(1);

        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            Timer.Text = (DateTime.Now - _StartTime).ToString(@"hh\:mm\:ss");

        }

        private void StartAndStop_Click(object sender, RoutedEventArgs e)
        {
            if (StartAndStop.Content.ToString() == "Start the Time")
            {
                _StartTime = DateTime.Now;
                dispatcherTimer.Start();
                _IsStopped = false;

                Save.Visibility = Visibility.Hidden;
                Description.Visibility = Visibility.Hidden;

                StartAndStop.Content = "Stop the Time";
                StartAndStop.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#0E78E8"));
            }

            else
            {
                dispatcherTimer.Stop();
                _IsStopped = true;

                StartAndStop.Content = "Start the Time";
                StartAndStop.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#6C3CA5"));

                Save.Visibility = Visibility.Visible;
                Description.Visibility = Visibility.Visible;
                Description.Text = "Entry " + Entry + "  " + _StartTime.ToString("hh:mm:ss tt");
            }

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (_IsStopped && Timer.Text != "00:00:00")
            {
                SaveList.Items.Add($"{Timer.Text}\t\t{_Description}");
                Entry ++;

                Timer.Text = "00:00:00";
                Save.Visibility = Visibility.Hidden;
                Description.Visibility = Visibility.Hidden;
            }

        }

        private void SaveList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                SaveList.Items.Remove(SaveList.SelectedItem);
            }

        }

    }
}

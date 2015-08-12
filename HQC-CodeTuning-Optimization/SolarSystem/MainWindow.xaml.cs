/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
namespace SolarSystem
{
    using System.Windows;

    public partial class MainWindow : Window
    {
        private OrbitsCalculator data = new OrbitsCalculator();

        public MainWindow()
        {
            this.DataContext = data;
            this.InitializeComponent();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            data.StartTimer();
        }

        private void Pause_Checked(object sender, RoutedEventArgs e)
        {
            data.Pause(true);
        }

        private void Pause_Unchecked(object sender, RoutedEventArgs e)
        {
            data.Pause(false);
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace lab13WeatherApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private WeatherViewModel _weatherViewModel;
        private WeatherService _weatherService;
        private LocationService _locationService;
        public MainWindow()
        {
            InitializeComponent();
            _weatherService = new WeatherService();
            _locationService = new LocationService();
            _weatherViewModel = new WeatherViewModel();
            _weatherViewModel.Cities = _locationService.GetCities().ToList();
            _weatherViewModel.Weather = _weatherService.GetWeather(_locationService.GetLocation(_weatherViewModel.Cities.First()));

            DataContext = _weatherViewModel;
        }

        private void CitiesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _weatherViewModel.Weather = _weatherService.GetWeather(_locationService.GetLocation(_weatherViewModel.SelectedCity));
        }
    }

    public class WeatherViewModel : INotifyPropertyChanged
    {
        public WeatherResponse Weather { get; set; }
        public string SelectedCity { get; set; }
        public List<string> Cities { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}

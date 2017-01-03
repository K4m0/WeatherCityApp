
using System.Collections.ObjectModel;
using WeatherCityApp.Model.Entities;

namespace WeatherCityApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {

        private ObservableCollection<City> _city;

        public ObservableCollection<City> City
        {
            get { return _city; }
            set { _city = value; OnPropertyChanged(); }
        }

        public MainPageViewModel()
        {
            City = new ObservableCollection<City>();
        }

        public void SetCityInfo(City cityInfo)
        {
            City.Add(cityInfo); 
        }


    }
}
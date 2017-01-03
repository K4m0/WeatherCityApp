
using WeatherCityApp.Model.Entities;
using WeatherCityApp.Model.Services;

namespace WeatherCityApp.ViewModels
{
    public class DetailWeatherViewModel : ViewModelBase
    {
       private readonly RestService _restService;

        private City SelectedCity { get; set; }

        private CityWeather _cityWeather;

        public CityWeather CityWeather
        {
            get { return _cityWeather; }
            set { _cityWeather = value; OnPropertyChanged(); }
        }

        public DetailWeatherViewModel()
        {
            _restService = new RestService();
            
        }

        private async void Load()
        {
            CityWeather = await _restService.GetCityWeatherInfoAsync(SelectedCity);
        }

        public void SetCityWeatherInfo(City selectedCity)
        {
            SelectedCity = selectedCity;
            Load();
        }
    }
}
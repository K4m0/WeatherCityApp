using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WeatherCityApp.ViewModels;

namespace WeatherCityApp.Model.Entities
{
    public class CityWeather : ObservableItem
    {
        private string _cityName;
        private string _cityCountry;
        private string _weather;
        private string _temp;
        private string _tempMin;
        private string _tempMax;
        private string _pressure;
        private string _humidity;
        private string _windSpeed;
        private string _windDirection;

        public string CityName
        {
            get { return _cityName; }
            set { _cityName = value; OnPropertyChanged(); }
        }

        public string CityCountry
        {
            get { return _cityCountry; }
            set { _cityCountry = value; OnPropertyChanged(); }
        }

        public string Weather
        {
            get { return _weather; }
            set { _weather = value; OnPropertyChanged(); }
        }

        public string Temp
        {
            get { return _temp; }
            set { _temp = value; OnPropertyChanged(); }
        }

        public string TempMin
        {
            get { return _tempMin; }
            set { _tempMin = value; OnPropertyChanged(); }
        }

        public string TempMax
        {
            get { return _tempMax; }
            set { _tempMax = value; OnPropertyChanged(); }
        }

        public string Pressure
        {
            get { return _pressure; }
            set { _pressure = value; OnPropertyChanged(); }
        }

        public string Humidity
        {
            get { return _humidity; }
            set { _humidity = value; OnPropertyChanged(); }
        }

        public string WindSpeed
        {
            get { return _windSpeed; }
            set { _windSpeed = value; OnPropertyChanged(); }
        }

        public string WindDirection
        {
            get { return _windDirection; }
            set { _windDirection = value; OnPropertyChanged(); }
        }
    }
}

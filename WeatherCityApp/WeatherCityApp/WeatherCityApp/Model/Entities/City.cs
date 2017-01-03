using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherCityApp.ViewModels;

namespace WeatherCityApp.Model.Entities
{
    public class City : ObservableItem
    {
        private string _name;
        private string _country;
        private string _countryCode;

        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(); }
        }

        public string Country
        {
            get { return _country; }
            set { _country = value; OnPropertyChanged(); }
        }

        public string CountryCode
        {
            get { return _countryCode; }
            set { _countryCode = value; OnPropertyChanged(); }
        }
    }
}

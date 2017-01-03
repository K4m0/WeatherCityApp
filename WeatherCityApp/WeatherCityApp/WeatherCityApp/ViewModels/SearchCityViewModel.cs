using System;
using System.Windows.Input;
using Xamarin.Forms;
using WeatherCityApp.Model.Entities;
using WeatherCityApp.Model.Services;
using WeatherCityApp.Pages;

namespace WeatherCityApp.ViewModels
{
    public class SearchCityViewModel : ViewModelBase
    {
        readonly RestService _restService;
        public Command SearchCommand { get; set; }

        private string _cityName;

        public string CityName
        {
            get { return _cityName; }
            set { _cityName = value; OnPropertyChanged(); }
        }

        public SearchCityViewModel()
        {
            _restService = new RestService();
            SearchCommand = new Command(() => Search());
        }

        public async void Search()
        {

            var cityInfo = await _restService.GetCityInfoAsync(_cityName);


            if (cityInfo.Name == "" || cityInfo.Name == null)
            {
                cityInfo.Name = _cityName;
                cityInfo.Country = "View Detail";
            }

            MainPage mainPage = new MainPage();
            var vm = mainPage.BindingContext as MainPageViewModel;
            vm.SetCityInfo(cityInfo);
            await Application.Current.MainPage.Navigation.PushAsync(mainPage);

        }
    }


}

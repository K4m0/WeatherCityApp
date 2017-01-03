using Xamarin.Forms;
using WeatherCityApp.Model.Entities;
using WeatherCityApp.ViewModels;

namespace WeatherCityApp.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = new MainPageViewModel();
            LvwCity.ItemSelected += LvwCity_ItemSelected;
        }

        private void LvwCity_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            City selectedCity = (City)e.SelectedItem;
            if (selectedCity == null)
                return;

            DetailWeatherPage detailWeatherPage = new DetailWeatherPage();
            var vm = detailWeatherPage.BindingContext as DetailWeatherViewModel;
            vm.SetCityWeatherInfo(selectedCity);

            Navigation.PushAsync(detailWeatherPage);
            LvwCity.SelectedItem = null;
        }
    }
}

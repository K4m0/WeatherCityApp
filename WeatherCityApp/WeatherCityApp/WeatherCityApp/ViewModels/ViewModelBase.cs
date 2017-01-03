using Xamarin.Forms;

namespace WeatherCityApp.ViewModels
{
    /// <summary>
    /// Representa el modelo base de la vista
    /// </summary>
    public class ViewModelBase : ObservableItem
    {
        /// <summary>
        /// Referencia a la MasterDetailPage
        /// </summary>
        public MasterDetailPage MasterPage
        {
            get
            {
                return (MasterDetailPage)this.CurrentPage;
            }
        }

        /// <summary>
        /// Referencia a la MasterDetailPage
        /// </summary>
        public Page CurrentPage
        {
            get
            {
                Page page = Application.Current.MainPage is NavigationPage
                    ? ((NavigationPage)Application.Current.MainPage).CurrentPage
                    : Application.Current.MainPage;

                return page;
            }
        }
    }
}
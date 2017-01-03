using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WeatherCityApp.ViewModels
{
    /// <summary>
    /// Objeto observable notificable de cambio en las propiedades.
    /// </summary>
    public abstract class ObservableItem : INotifyPropertyChanged
    {
        #region Property Changed Implementation

        /// <summary>
        /// Evento cuando el valor de la propiedad cambia.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Evento cuando el valor de la propiedad cambia.
        /// </summary>
        /// <param name="propertyName">Nombre de la propiedad.</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}

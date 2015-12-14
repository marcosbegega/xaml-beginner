using System.ComponentModel;
using System.Runtime.CompilerServices;
using RestaurantManager.Models;

namespace RestaurantManager.ViewModels
{
    public abstract class ViewModel :INotifyPropertyChanged
    {
        protected RestaurantContext Repository { get; private set; }

        public ViewModel()
        {
            LoadData();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private async void LoadData()
        {
            this.Repository = await RestaurantContextFactory.GetRestaurantContextAsync();

            OnDataLoaded();
        }

        protected abstract void OnDataLoaded();

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}

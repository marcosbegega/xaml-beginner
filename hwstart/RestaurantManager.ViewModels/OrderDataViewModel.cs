using System.Collections.Generic;
using System.Collections.ObjectModel;
using RestaurantManager.Models;

namespace RestaurantManager.ViewModels
{
    public class OrderDataViewModel : ViewModel
    {       
        protected override void OnDataLoaded()
        {
            this.MenuItems = base.Repository.StandardMenuItems;

            this.CurrentlySelectedMenuItems = new ObservableCollection<MenuItem>
            {
                this.MenuItems[3],
                this.MenuItems[5]
            };
        }

        private List<MenuItem>  menuItems;

        public List<MenuItem> MenuItems
        {
          get { return menuItems; }
          set
            {
                if (value != menuItems)
                {
                    menuItems = value;

                    OnPropertyChanged();
                }
            }
        }

        private ObservableCollection<MenuItem> currentlySelectedMenuItems;

        public ObservableCollection<MenuItem> CurrentlySelectedMenuItems
        {
          get { return currentlySelectedMenuItems; }
          set
            {
                if (value != currentlySelectedMenuItems)
                {
                    currentlySelectedMenuItems = value;

                    OnPropertyChanged();
                }
            }
        }
    }
}

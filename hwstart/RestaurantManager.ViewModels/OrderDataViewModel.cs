using System.Collections.Generic;
using System.Collections.ObjectModel;
using RestaurantManager.Models;
using System.Windows.Input;
using ViewModels;

namespace RestaurantManager.ViewModels
{
    public class OrderDataViewModel : ViewModel
    {
        public OrderDataViewModel()
        {
            AddToOrderCommand = new DelegateCommand<MenuItem>(AddToSelected);
        }
           
        protected override void OnDataLoaded()
        {
            this.MenuItems = base.Repository.StandardMenuItems;

            this.CurrentlySelectedMenuItems = new ObservableCollection<MenuItem>();
        }

        public ICommand AddToOrderCommand { get; set; }

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

        private void AddToSelected(MenuItem item)
        {
            if (!this.CurrentlySelectedMenuItems.Contains(item))
            {
                this.CurrentlySelectedMenuItems.Add(item);
            }
        }
    }
}

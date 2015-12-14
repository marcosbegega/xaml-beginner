using System.Collections.Generic;
using System.Collections.ObjectModel;
using RestaurantManager.Models;
using System.Windows.Input;
using ViewModels;
using System.Linq;

namespace RestaurantManager.ViewModels
{
    public class OrderDataViewModel : ViewModel
    {
        public OrderDataViewModel()
        {
            AddToOrderCommand = new DelegateCommand<MenuItem>(AddToSelected);
            SubmitOrderCommand = new DelegateCommand<object>(SubmitOrder);
        }
           
        protected override void OnDataLoaded()
        {
            this.MenuItems = base.Repository.StandardMenuItems;

            this.CurrentlySelectedMenuItems = new ObservableCollection<MenuItem>();
        }

        public ICommand AddToOrderCommand { get; set; }
        public ICommand SubmitOrderCommand { get; set; }

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

        private void SubmitOrder(object parameter)
        {
            Order order = new Order();

            order.Id = (from Order o in base.Repository.Orders
                        select o.Id).Max();

            order.Table = base.Repository.Tables[0];

            order.Items = new List<MenuItem>();
            order.Items.AddRange(this.CurrentlySelectedMenuItems);

            base.Repository.Orders.Add(order);
        }
    }
}

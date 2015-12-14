using System.Collections.Generic;
using RestaurantManager.Models;

namespace RestaurantManager.ViewModels
{
    public class ExpediteDataViewModel : ViewModel
    {
        protected override void OnDataLoaded()
        {
            this.OrderItems = base.Repository.Orders;
        }

        private List<Order> orderItems;

        public List<Order> OrderItems
        {
            get { return orderItems; }
            set
            {
                if (value != orderItems)
                {
                    orderItems = value;

                    OnPropertyChanged("OrderItems");
                }
            }
        }
    }
}

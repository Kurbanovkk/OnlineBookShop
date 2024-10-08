﻿namespace OnlineBookShop
{
    public enum OrderStatuses
    {
        Created,
        Processed,
        Delivering,
        Delivered,
        Canceled
    }
    public class OrderViewModel
    {
        public Guid Id { get; set;}

        public UserDeliveryInfoViewModel User { get; set; }
        public List<CartItemViewModel> Items { get; set; }
        public string CreateOrder { get; set; }
        public string EditStatusOrder { get; set; }
        public OrderStatuses Status { get; set; }
        public decimal Amount
        {
            get
            {
                return Items.Sum(x => x.Cost);
            }
        }
        public OrderViewModel() 
        {
            Id = Guid.NewGuid();
            CreateOrder = DateTime.Now.ToString("dd-MM-yyyy HH:mm");
            EditStatusOrder = DateTime.Now.ToString("dd-MM-yyyy HH:mm");
            Status = OrderStatuses.Created;
        }
    }
}

using System;

namespace CampaignModule.Models
{
    class Order
    {
        public Order(string productCode, double price, double quantity, Campaign campaign)
        {
            ProductCode = productCode;
            Price = price;
            Quantity = quantity;
            Campaign = campaign;
            
            Id = Guid.NewGuid();
        }

        public string ProductCode { get; set; }
        public double Price { get; set; }
        public double Quantity { get; set; }
        public Campaign Campaign{get;set;}
        public Guid Id { get; }
    }
}
using System;

namespace CampaignModule.Models
{
    class Product
    {
        public Product(string productCode, double price, double stock)
        {
            ProductCode = productCode;
            Price = price;
            this.stock = stock;
            Id = Guid.NewGuid();
        }

        public string ProductCode { get; }
        public double Price { get; }

        private double stock;

        public double GetStock()
        {
            return stock;
        }

        private void SetStock(double value){
            this.stock = value;
        }

        public Guid Id { get; }

        public void decreaseStock(double value){
            stock -= value;
        }
    }
}
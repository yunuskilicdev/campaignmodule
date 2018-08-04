namespace CampaignModule.Models
{
    class Order
    {
        public int ID { get; set; }
        public string ProductCode { get; set; }
        public double Price { get; set; }
        public double Quantity { get; set; }
    }
}
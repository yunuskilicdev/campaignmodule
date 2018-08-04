namespace CampaignModule.Models
{
    class Product
    {
        private int _ıD;
        private string _productCode;

        public Product(string productCode, string price, string stock)
        {
            SetProductCode(productCode);
            SetPrice(double.Parse(price));
            SetStock(double.Parse(stock));
        }

        public int GetID()
        {
            return _ıD;
        }

        public void SetID(int value)
        {
            _ıD = value;
        }

        public string GetProductCode()
        {
            return _productCode;
        }

        public void SetProductCode(string value)
        {
            _productCode = value;
        }

        private double price;

        public double GetPrice()
        {
            return price;
        }

        public void SetPrice(double value)
        {
            price = value;
        }

        private double stock;

        public double GetStock()
        {
            return stock;
        }

        public void SetStock(double value)
        {
            stock = value;
        }
    }
}
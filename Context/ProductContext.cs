using System.Collections.Generic;
using System.Linq;
using CampaignModule.Models;

namespace CampaignModule.Context
{
    class ProductContext
    {
        private static List<Product> products = new List<Product>();

        public List<Product> list()
        {
            return products;
        }

        public bool add(Product product)
        {
            if (!list().Contains(product))
            {
                products.Add(product);
                return true;
            }
            return false;
        }

        public Product get(string productCode)
        {
            var filterResponse = list().Where(x => x.GetProductCode().Equals(productCode));
            return filterResponse.Single();
        }
    }
}
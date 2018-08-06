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
            if (list().Where(x => x.ProductCode.Equals(product.ProductCode)).Count() == 0)
            {
                products.Add(product);
                return true;
            }
            return false;
        }

        public Product get(string productCode)
        {
            return list().Where(x => x.ProductCode.Equals(productCode)).SingleOrDefault();
        }

        public bool update(Product product)
        {
            Product existing = list().Where(x => x.ProductCode.Equals(product.ProductCode)).FirstOrDefault();
            if (existing.Equals(default(Product))) { return false; }
            list().Remove(existing);
            products.Add(product);
            return true;
        }
    }
}
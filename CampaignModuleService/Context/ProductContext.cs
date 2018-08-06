using System.Collections.Generic;
using System.Linq;
using CampaignModule.Models;

namespace CampaignModule.Context
{
    class ProductContext
    {
        private static List<Product> products = new List<Product>();

        public List<Product> List()
        {
            return products;
        }

        public bool Add(Product product)
        {
            if (List().Where(x => x.ProductCode.Equals(product.ProductCode)).Count() == 0)
            {
                products.Add(product);
                return true;
            }
            return false;
        }

        public Product Get(string productCode)
        {
            return List().Where(x => x.ProductCode.Equals(productCode)).SingleOrDefault();
        }

        public bool Update(Product product)
        {
            Product existing = List().Where(x => x.ProductCode.Equals(product.ProductCode)).FirstOrDefault();
            if (existing.Equals(default(Product))) { return false; }
            List().Remove(existing);
            products.Add(product);
            return true;
        }
    }
}
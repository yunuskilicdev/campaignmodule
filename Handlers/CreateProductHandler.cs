using System.Collections.Generic;
using CampaignModule.Context;
using CampaignModule.Models;

namespace CampaignModule.Handlers
{
    class CreateProductHandler : CommandHandler
    {
        public override string execute(List<string> parameters)
        {
            if (parameters.Count != 4) { return "ERROR"; }
            try
            {
                string productCode = parameters[1];
                double price = double.Parse(parameters[2]);
                double stock = double.Parse(parameters[3]);
                Product product = new Product(productCode, price, stock);
                ProductContext context = new ProductContext();
                bool result = context.add(product);
                if (!result)
                {
                    return "ERROR";
                }
                else
                {
                    return $"Product created; code {productCode}, price {price}, stock {stock}";
                }
            }
            catch (System.Exception)
            {
                return "ERROR";
            }

        }
    }
}
using System.Collections.Generic;
using CampaignModule.Context;
using CampaignModule.Models;

namespace CampaignModule.Handlers
{
    class CreateOrderHandler : CommandHandler
    {

        public override string execute(List<string> parameters)
        {
            if (parameters.Count != 3) { return "ERROR"; }
            try
            {
                string productCode = parameters[1];
                double quantity = double.Parse(parameters[2]);
                ProductContext productContext = new ProductContext();
                Product product = productContext.get(productCode);
                if (product == null) { return "ERROR"; }
                if (product.GetStock() < quantity) { return "ERROR"; }
                product.decreaseStock(quantity);
                productContext.update(product);
                return $"Order created; product {productCode}, quantity {quantity}";
            }
            catch (System.Exception)
            {
                return "ERROR";
            }
        }
    }
}
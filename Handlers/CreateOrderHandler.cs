using System.Collections.Generic;
using CampaignModule.Context;
using CampaignModule.Models;

namespace CampaignModule.Handlers
{
    class CreateOrderHandler : CommandHandler
    {

        public override string execute(List<string> parameters)
        {
            if (parameters.Count != 3) { return ErrorType.PARAMETER_IS_NOT_SUFFICIENT.ToString(); }
            try
            {
                string productCode = parameters[1];
                double quantity = double.Parse(parameters[2]);
                ProductContext productContext = new ProductContext();
                Product product = productContext.get(productCode);
                if (product == null) { return ErrorType.PRODUCT_NOT_FOUND.ToString(); }
                if (product.GetStock() < quantity) { return ErrorType.PRODUCT_STOCK_IS_NOT_SUFFICIENT.ToString(); }
                product.decreaseStock(quantity);
                CampaignContext campaignContext = new CampaignContext();
                var response = campaignContext.priceByProduct(product);
                Order order = new Order(productCode,response.Item1,quantity,response.Item2);
                OrderContext orderContext = new OrderContext();
                orderContext.add(order);
                return $"Order created; product {productCode}, quantity {quantity}";
            }
            catch (System.Exception)
            {
                return ErrorType.UNKNOWN_EXCEPTION.ToString();
            }
        }
    }
}
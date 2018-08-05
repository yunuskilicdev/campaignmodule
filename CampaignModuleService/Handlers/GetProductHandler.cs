using System;
using System.Collections.Generic;
using CampaignModule.Context;
using CampaignModule.Models;

namespace CampaignModule.Handlers
{
    public class GetProductHandler : CommandHandler
    {
        public override string execute(List<string> parameters)
        {
            if (parameters.Count != 2) { return ErrorType.PARAMETER_IS_NOT_SUFFICIENT.ToString();; }
            try
            {
                string productCode = parameters[1];
                ProductContext context = new ProductContext();
                Product product = context.get(productCode);
                if (product == null)
                {
                    return ErrorType.PRODUCT_NOT_FOUND.ToString();
                }
                else
                {
                    CampaignContext campaignContext = new CampaignContext();
                    Tuple<double, Campaign> response = campaignContext.priceByProduct(product);
                    return $"Product {product.ProductCode} info; price {response.Item1}, stock {product.GetStock()}";
                }
            }
            catch (System.Exception)
            {
                return ErrorType.UNKNOWN_EXCEPTION.ToString();
            }
        }
    }
}
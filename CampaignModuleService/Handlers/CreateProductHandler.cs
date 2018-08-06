using System.Collections.Generic;
using CampaignModule.Context;
using CampaignModule.Models;

namespace CampaignModule.Handlers
{
    public class CreateProductHandler : CommandHandler
    {
        public override string Execute(List<string> parameters)
        {
            if (parameters.Count != 4) { return ErrorType.PARAMETER_IS_NOT_SUFFICIENT.ToString();; }
            try
            {
                string productCode = parameters[1];
                double price = double.Parse(parameters[2]);
                double stock = double.Parse(parameters[3]);
                Product product = new Product(productCode, price, stock);
                ProductContext context = new ProductContext();
                bool result = context.Add(product);
                if (!result)
                {
                    return ErrorType.PRODUCT_ALREADY_EXISTS.ToString();
                }
                else
                {
                    return $"Product created; code {productCode}, price {price}, stock {stock}";
                }
            }
            catch (System.Exception)
            {
                return ErrorType.UNKNOWN_EXCEPTION.ToString();
            }

        }
    }
}
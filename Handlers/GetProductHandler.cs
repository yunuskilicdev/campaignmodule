using System;
using System.Collections.Generic;
using CampaignModule.Context;
using CampaignModule.Models;

namespace CampaignModule.Handlers
{
    class GetProductHandler : CommandHandler
    {
        public override string execute(List<string> parameters)
        {
            if (parameters.Count != 2) { return "ERROR"; }
            try
            {
                string productCode = parameters[1];
                ProductContext context = new ProductContext();
                Product product = context.get(productCode);
                if (product == null)
                {
                    return "ERROR";
                }
                else
                {
                    double price = product.Price;
                    CampaignContext campaignContext = new CampaignContext();
                    Campaign campaign = campaignContext.activeCampaign(productCode);
                    if (campaign != null)
                    {
                        int currentTime = Time.getTime();
                        int diff = currentTime - campaign.StartTime;
                        double discountRate = campaign.PmLimit / campaign.Duration * diff;
                        if (discountRate > 0)
                        {
                            if (discountRate > campaign.PmLimit)
                            {
                                discountRate = campaign.PmLimit;
                            }
                            price = (int)(price * (1 - discountRate / 100));
                        }

                    }

                    return $"Product {product.ProductCode} info; price {price}, stock {product.GetStock()}";
                }
            }
            catch (System.Exception)
            {
                return "ERROR";
            }
        }
    }
}
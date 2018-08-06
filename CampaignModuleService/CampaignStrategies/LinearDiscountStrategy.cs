using System;
using System.Linq;
using CampaignModule.Context;
using CampaignModule.Models;

namespace CampaignModule.CampaignStrategies{
    public class LinearDiscountStrategy : ICampaignStrategy
    {
        public Tuple<double, Campaign> PriceByProduct(Product product)
        {
            CampaignContext campaignContext = new CampaignContext();
            double price = product.Price;
            Campaign campaign = campaignContext.List().Where(x => x.GetActive() == true && x.ProductCode.Equals(product.ProductCode)).SingleOrDefault();
            if (campaign != null)
            {
                int currentTime = Time.GetTime();
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

            return Tuple.Create(price, campaign);
        }
    }
}
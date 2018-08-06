using System;
using System.Collections.Generic;
using System.Linq;
using CampaignModule.Models;

namespace CampaignModule.Context
{
    class CampaignContext
    {
        private static List<Campaign> campaigns = new List<Campaign>();

        public List<Campaign> List()
        {
            return campaigns;
        }

        public bool Add(Campaign campaign)
        {
            if (List().Where(x => x.ProductCode.Equals(campaign.ProductCode) && x.GetActive() == true).Count() == 0)
            {
                campaigns.Add(campaign);
                return true;
            }
            return false;
        }

        internal Campaign GetByName(string v)
        {
            return List().Where(x => x.Name.Equals(v)).SingleOrDefault();
        }

        internal void DeactiveAll(List<Campaign> updateList)
        {
            foreach (var item in updateList)
            {
                Campaign current = campaigns.Where(x => x.Id == item.Id).SingleOrDefault();
                current.Deactivate();
            }
        }


        public List<Campaign> ActiveCampaign()
        {
            IEnumerable<Campaign> response = List().Where(x => x.GetActive() == true);
            if (response != null && response.Count() > 0)
            {
                return response.ToList();
            }
            return null;
        }

        public Tuple<double, Campaign> PriceByProduct(Product product)
        {
            double price = product.Price;
            Campaign campaign = List().Where(x => x.GetActive() == true && x.ProductCode.Equals(product.ProductCode)).SingleOrDefault();
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
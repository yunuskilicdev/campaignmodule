using System;
using System.Collections.Generic;
using System.Linq;
using CampaignModule.Models;

namespace CampaignModule.Context
{
    class CampaignContext
    {
        private static List<Campaign> campaigns = new List<Campaign>();

        public List<Campaign> list()
        {
            return campaigns;
        }

        public bool add(Campaign campaign)
        {
            if (list().Where(x => x.ProductCode.Equals(campaign.ProductCode) && x.GetActive() == true).Count() == 0)
            {
                campaigns.Add(campaign);
                return true;
            }
            return false;
        }

        internal void DeactiveAll(List<Campaign> updateList)
        {
            foreach (var item in updateList)
            {
                Campaign current = campaigns.Where(x => x.Id == item.Id).SingleOrDefault();
                current.deactivate();
            }
        }

        internal void UpdateAll(List<Campaign> updateList)
        {

        }

        public List<Campaign> activeCampaign()
        {
            IEnumerable<Campaign> response = list().Where(x => x.GetActive() == true);
            if (response != null && response.Count() > 0)
            {
                return response.ToList();
            }
            return null;
        }

        public Campaign activeCampaign(string productCode)
        {
           return list().Where(x => x.GetActive() == true && x.ProductCode.Equals(productCode)).SingleOrDefault();
        }
    }
}
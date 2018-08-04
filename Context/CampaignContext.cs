using System.Collections.Generic;
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
            if (!list().Contains(campaign))
            {
                campaigns.Add(campaign);
                return true;
            }
            return false;
        }
    }
}
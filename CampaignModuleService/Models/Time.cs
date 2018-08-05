using System;
using System.Collections.Generic;
using System.Linq;
using CampaignModule.Context;

namespace CampaignModule.Models
{
    class Time
    {
        private static int current = 0;

        public static string increaseTime(int param)
        {
            current += param;
            CampaignContext campaignContext = new CampaignContext();
            List<Campaign> list = campaignContext.activeCampaign();

            List<Campaign> updateList = list.Where(x => x.StartTime + x.Duration <= current).ToList();
            campaignContext.DeactiveAll(updateList);
            return $"Time is {current}:00";
        }

        public static int getTime()
        {
            return current;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using CampaignModule.Models;

namespace CampaignModule.Context
{
    class OrderContext
    {
        private static List<Order> orders = new List<Order>();

        public List<Order> List()
        {
            return orders;
        }

        public bool Add(Order order)
        {
            if (!List().Contains(order))
            {
                orders.Add(order);
                return true;
            }
            return false;
        }

        internal List<Order> GetOrdersByCampaign(Campaign campaign)
        {
            return List().Where(x=>x.Campaign!=null&&x.Campaign.Name.Equals(campaign.Name)).ToList();
        }
    }
}
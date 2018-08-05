using System;
using System.Collections.Generic;
using System.Linq;
using CampaignModule.Models;

namespace CampaignModule.Context
{
    class OrderContext
    {
        private static List<Order> orders = new List<Order>();

        public List<Order> list()
        {
            return orders;
        }

        public bool add(Order order)
        {
            if (!list().Contains(order))
            {
                orders.Add(order);
                return true;
            }
            return false;
        }

        internal List<Order> getOrdersByCampaign(Campaign campaign)
        {
            return list().Where(x=>x.Campaign!=null&&x.Campaign.Name.Equals(campaign.Name)).ToList();
        }
    }
}
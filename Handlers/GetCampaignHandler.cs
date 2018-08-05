using System.Collections.Generic;
using System.Linq;
using CampaignModule.Context;
using CampaignModule.Models;

namespace CampaignModule.Handlers
{
    class GetCampaignHandler : CommandHandler
    {

        public override string execute(List<string> parameters)
        {
            if (parameters.Count != 2) { return "ERROR"; }
            CampaignContext campaignContext = new CampaignContext();
            Campaign campaign = campaignContext.getByName(parameters[1]);
            if (campaign == null) return "ERROR";
            OrderContext orderContext = new OrderContext();
            List<Order> orders = orderContext.getOrdersByCampaign(campaign);
            string statusDesc = "";
            if (campaign.GetActive() == true) statusDesc = "Not Ended";
            else statusDesc = "Ended";
            double totalSales = orders.Sum(x => x.Quantity);
            double totalRevenue = orders.Sum(x => x.Price * x.Quantity);
            double averagePrice = totalRevenue / totalSales;
            double turnover = totalSales / campaign.TargetSalesCount;
            return $"Campaign {campaign.Name} info; Status {statusDesc}, Target Sales {campaign.TargetSalesCount},Total Sales {totalSales}, Turnover {turnover}, Average Item Price {averagePrice}";
        }
    }
}
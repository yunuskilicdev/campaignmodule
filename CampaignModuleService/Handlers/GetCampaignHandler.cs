using System.Collections.Generic;
using System.Linq;
using CampaignModule.Context;
using CampaignModule.Models;

namespace CampaignModule.Handlers
{
    public class GetCampaignHandler : CommandHandler
    {

        public override string execute(List<string> parameters)
        {
            if (parameters.Count != 2) { return ErrorType.PARAMETER_IS_NOT_SUFFICIENT.ToString(); }
            CampaignContext campaignContext = new CampaignContext();
            Campaign campaign = campaignContext.getByName(parameters[1]);
            if (campaign == null) return ErrorType.CAMPAIGN_NOT_FOUND.ToString();
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
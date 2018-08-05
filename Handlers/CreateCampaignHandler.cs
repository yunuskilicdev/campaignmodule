using System.Collections.Generic;
using CampaignModule.Context;
using CampaignModule.Models;

namespace CampaignModule.Handlers
{
    class CreateCampaignHandler : CommandHandler
    {

        public override string execute(List<string> parameters)
        {
            if (parameters.Count != 6) { return "ERROR"; }
            try
            {
                string name = parameters[1];
                string productCode = parameters[2];
                int duration = int.Parse(parameters[3]);
                int pmLimit = int.Parse(parameters[4]);
                int targetSalesCount = int.Parse(parameters[5]);
                CampaignContext context = new CampaignContext();
                Campaign campaign = new Campaign(name, productCode, Time.getTime(), duration, pmLimit, targetSalesCount);
                bool result = context.add(campaign);
                if (!result)
                {
                    return "ERROR";
                }
                else
                {
                    return $"Campaign created; name {name}, product {productCode}, duration {duration}, limit {pmLimit}, target sales count {targetSalesCount}";
                };

            }
            catch (System.Exception)
            {
                return "ERROR";
            }
        }
    }
}
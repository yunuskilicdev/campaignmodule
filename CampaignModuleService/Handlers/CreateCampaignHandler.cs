using System.Collections.Generic;
using CampaignModule.Context;
using CampaignModule.Models;

namespace CampaignModule.Handlers
{
    public class CreateCampaignHandler : CommandHandler
    {

        public override string Execute(List<string> parameters)
        {
            if (parameters.Count != 6) { return ErrorType.PARAMETER_IS_NOT_SUFFICIENT.ToString(); }
            try
            {
                string name = parameters[1];
                string productCode = parameters[2];
                int duration = int.Parse(parameters[3]);
                int pmLimit = int.Parse(parameters[4]);
                int targetSalesCount = int.Parse(parameters[5]);
                CampaignContext context = new CampaignContext();
                Campaign campaign = new Campaign(name, productCode, Time.GetTime(), duration, pmLimit, targetSalesCount);
                bool result = context.Add(campaign);
                if (!result)
                {
                    return ErrorType.CAMPAIGN_ALREADY_EXISTS.ToString();
                }
                else
                {
                    return $"Campaign created; name {name}, product {productCode}, duration {duration}, limit {pmLimit}, target sales count {targetSalesCount}";
                };

            }
            catch (System.Exception)
            {
                return ErrorType.UNKNOWN_EXCEPTION.ToString();
            }
        }
    }
}
using System.Collections.Generic;
using CampaignModule.Models;

namespace CampaignModule.Handlers
{
    class IncreaseTimeHandler : CommandHandler
    {

        public override string execute(List<string> parameters)
        {
            Time.increaseTime(int.Parse(parameters[1]));
            return "";
        }
    }
}
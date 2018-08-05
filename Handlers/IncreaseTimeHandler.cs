using System.Collections.Generic;
using CampaignModule.Models;

namespace CampaignModule.Handlers
{
    class IncreaseTimeHandler : CommandHandler
    {

        public override string execute(List<string> parameters)
        {
            if (parameters.Count != 2) { return "ERROR"; }
            return Time.increaseTime(int.Parse(parameters[1]));
        }
    }
}
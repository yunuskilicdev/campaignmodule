using System.Collections.Generic;
using CampaignModule.Models;

namespace CampaignModule.Handlers
{
    public class IncreaseTimeHandler : CommandHandler
    {
        public override string execute(List<string> parameters)
        {
            if (parameters.Count != 2) { return ErrorType.PARAMETER_IS_NOT_SUFFICIENT.ToString(); }
            return Time.increaseTime(int.Parse(parameters[1]));
        }
    }
}
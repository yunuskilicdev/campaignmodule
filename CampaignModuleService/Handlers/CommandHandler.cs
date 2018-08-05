using System.Collections.Generic;

namespace CampaignModule.Handlers
{
    public abstract class CommandHandler
    {
        public abstract string execute(List<string> parameters);
    }
}
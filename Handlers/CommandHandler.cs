using System.Collections.Generic;

namespace CampaignModule.Handlers
{
    abstract class CommandHandler
    {
        public abstract string execute(List<string> parameters);
    }
}
using System.Collections.Generic;

namespace CampaignModule.Handlers
{
    abstract class CommandHandler
    {
        public string executeCommand(List<string> parameters)
        {
            if (commandValidation(parameters).Count > 0)
                return "ERROR";
            return execute(parameters);
        }

        protected abstract List<string> commandValidation(List<string> parameters);

        protected abstract string execute(List<string> parameters);
    }
}
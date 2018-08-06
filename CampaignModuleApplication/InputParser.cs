using System;
using System.Collections.Generic;
using System.Linq;
using CampaignModule.Context;
using CampaignModule.Handlers;
using CampaignModule.Models;

namespace CampaignModuleApplication
{
    class InputParser
    {
        private const string createProduct = "create_product";
        private const string getProduct = "get_product_info";
        private const string createOrder = "create_order";
        private const string createCampaign = "create_campaign";
        private const string getCampaign = "get_campaign_info";
        private const string increaseTime = "increase_time";
        public string[] parseInput(String input)
        {
            CommandHandler commandHandler;
            List<string> list = input.Split(' ').ToList();
            if (list.Contains(createProduct))
            {
                commandHandler = new CreateProductHandler();
            }
            else if (list.Contains(getProduct))
            {
                commandHandler = new GetProductHandler();
            }
            else if (list.Contains(createOrder))
            {
                commandHandler = new CreateOrderHandler();
            }
            else if (list.Contains(createCampaign))
            {
                commandHandler = new CreateCampaignHandler();
            }
            else if (list.Contains(getCampaign))
            {
                commandHandler = new GetCampaignHandler();
            }
            else if (list.Contains(increaseTime))
            {
                commandHandler = new IncreaseTimeHandler();
            }
            else
            {
                return null;
            }
            Console.WriteLine(commandHandler.Execute(list));
            return null;
        }
    }
}

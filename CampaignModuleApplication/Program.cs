﻿using System;
using CampaignModule.Context;
using CampaignModule.Models;

namespace CampaignModuleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-1 or EXIT to close");
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "-1" || input.ToUpper() == "EXIT") break;
                InputParser inputParser = new InputParser();
                inputParser.parseInput(input);
            }
        }
    }
}

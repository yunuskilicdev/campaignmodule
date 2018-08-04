using System;
using CampaignModule.Context;
using CampaignModule.Models;

namespace CampaignModule
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "-1" || input.ToUpper() == "EXIT") break;
                

            }
            Console.WriteLine("Hello World!");
        }
    }
}

using System;
using CampaignModule.Models;

namespace CampaignModule.CampaignStrategies{
    public interface ICampaignStrategy
    {
        Tuple<double, Campaign> PriceByProduct(Product product);
    }
}
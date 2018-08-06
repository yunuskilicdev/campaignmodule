using System;
using System.Collections.Generic;
using CampaignModule.Handlers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CampaignModule.UnitTests.Services
{
    [TestClass]
    public class CreateCampaignTest
    {
        private readonly CreateCampaignHandler _creteCampaignHandler;

        public CreateCampaignTest()
        {
            _creteCampaignHandler = new CreateCampaignHandler();
        }

        [TestMethod]
        public void ValidCreation()
        {
            List<string> list = new List<string>();
            list.Add("create_campaign");
            list.Add("C1");
            list.Add("P1");
            list.Add("10");
            list.Add("20");
            list.Add("100");
            string response = _creteCampaignHandler.Execute(list);
            Console.WriteLine(response);
            Assert.AreEqual(response,"Campaign created; name C1, product P1, duration 10, limit 20, target sales count 100");
        }

        [TestMethod]
        public void InvalidCreation()
        {
            List<string> list = new List<string>();
            list.Add("create_campaign");
            list.Add("C1");
            list.Add("P1");
            list.Add("20");
            list.Add("100");
            string response = _creteCampaignHandler.Execute(list);
            Console.WriteLine(response);
            Assert.AreEqual(response,"PARAMETER_IS_NOT_SUFFICIENT");
        }
    }
}
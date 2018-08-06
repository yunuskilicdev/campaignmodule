using System;
using System.Collections.Generic;
using CampaignModule.Handlers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CampaignModule.UnitTests.Services
{
    [TestClass]
    public class CreateProductTest
    {
        private readonly CreateProductHandler _createProductHandler;

        public CreateProductTest()
        {
            _createProductHandler = new CreateProductHandler();
        }

        [TestMethod]
        public void ValidCreation()
        {
            List<string> list = new List<string>();
            list.Add("create_product");
            list.Add("P1");
            list.Add("100");
            list.Add("1000");
            string response = _createProductHandler.execute(list);
            Console.WriteLine(response);
            Assert.AreEqual(response,"Product created; code P1, price 100, stock 1000");
        }

        [TestMethod]
        public void InvalidCreation()
        {
            List<string> list = new List<string>();
            list.Add("create_product");
            list.Add("P1");
            list.Add("100");
            string response = _createProductHandler.execute(list);
            Console.WriteLine(response);
            Assert.AreEqual(response,"PARAMETER_IS_NOT_SUFFICIENT");
        }
    }
}
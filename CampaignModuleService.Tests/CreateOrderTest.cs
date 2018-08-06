using System;
using System.Collections.Generic;
using CampaignModule.Handlers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CampaignModule.UnitTests.Services
{
    [TestClass]
    public class CreateOrderTest
    {
        private readonly CreateOrderHandler _createOrderHandler;

        private readonly CreateProductHandler _createProductHandler;

        public CreateOrderTest()
        {
            _createOrderHandler = new CreateOrderHandler();
            _createProductHandler = new CreateProductHandler();
        }

        [TestMethod]
        public void InvalidProduct()
        {
            List<string> list = new List<string>();
            list.Add("create_order");
            list.Add("P2");
            list.Add("3");
            string response = _createOrderHandler.execute(list);
            Console.WriteLine(response);
            Assert.AreEqual(response, "PRODUCT_NOT_FOUND");
        }

        [TestMethod]
        public void InvalidCreation()
        {
            List<string> list = new List<string>();
            list.Add("create_order");
            list.Add("P1");
            string response = _createOrderHandler.execute(list);
            Console.WriteLine(response);
            Assert.AreEqual(response, "PARAMETER_IS_NOT_SUFFICIENT");
        }
    }
}
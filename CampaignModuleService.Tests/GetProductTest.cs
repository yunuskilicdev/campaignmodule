using System;
using System.Collections.Generic;
using CampaignModule.Handlers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CampaignModule.UnitTests.Services
{
    [TestClass]
    public class GetProductTest
    {
        private readonly GetProductHandler _getProductHandler;
        private readonly CreateProductHandler _createProductHandler;

        public GetProductTest()
        {
            _getProductHandler = new GetProductHandler();
            _createProductHandler = new CreateProductHandler();
        }

        [TestMethod]
        public void ValidGet()
        {
            List<string> list = new List<string>();
            list.Add("get_product");
            list.Add("P1");
            string response = _getProductHandler.execute(list);
            Assert.AreEqual(response,"Product P1 info; price 100, stock 1000");
        }

        [TestMethod]
        public void InvalidGet()
        {
            List<string> list = new List<string>();
            list.Add("get_product");
            list.Add("P2");
            string response = _getProductHandler.execute(list);
            Assert.AreEqual(response,"PRODUCT_NOT_FOUND");
        }
    }
}
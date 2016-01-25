using ChristiaanVerwijs.MvcSiteWithEntityFramework.Repositories;
using ChristiaanVerwijs.MvcSiteWithEntityFramework.WebSite.Controllers;
using ChristiaanVerwijs.MvcSiteWithEntityFramework.WebSite.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Web.Routing;
using System.Collections.Generic;
using System.Collections;
using System.Web.Mvc;
using System.Linq;
using System;

namespace ChristiaanVerwijs.MvcSiteWithEntityFramework.WebSite.Tests
{
    [TestClass]
    public class HomeControllerTests
    {
        [TestInitialize]
        public void TestInitialize()
        {
        }

        [TestMethod]
        public void Index_redirects_to_application_index()
        {
            var controller = CreateInstance();
            var result = (RedirectToRouteResult)controller.Index();

            Assert.AreEqual("Application", result.RouteValues["Controller"]);
            Assert.AreEqual("Index", result.RouteValues["Action"]);
        }

        private HomeController CreateInstance()
        {
            return new HomeController();
        }
    }
}

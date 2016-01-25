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
    public class ApplicationListViewModelTests
    {
        [TestMethod]
        public void Constructor_populates_view_model_with_list_of_applications()
        {
            // setup
            var application1 = new ApplicationBuilder().WithName("A").WithDefaultTeam().Build();
            var application2 = new ApplicationBuilder().WithName("B").WithDefaultTeam().Build();

            // act
            var model = new ApplicationListViewModel(new List<Application>() { application1, application2 });

            // verify
            Assert.AreEqual(2, model.Applications.Count());
            Assert.AreEqual(application1.Id, model.Applications[0].Id);
            Assert.AreEqual(application2.Id, model.Applications[1].Id);
        }
    }
}

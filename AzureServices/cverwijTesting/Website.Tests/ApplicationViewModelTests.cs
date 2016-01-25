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
    public class ApplicationViewModelTests
    {
        [TestMethod]
        public void Constructor_populates_viewmodel_with_application_properties_if_one_is_supplied()
        {
            // setup
            var application = new ApplicationBuilder().WithName("Name").WithDefaultTeam().Build();

            // act
            var model = new ApplicationViewModel(application);

            // verify
            Assert.AreEqual(application.Id, model.Id);
            Assert.AreEqual(application.Name, model.Name);
            Assert.AreEqual(application.Description, model.Description);
            Assert.AreEqual(application.TeamId, model.TeamId);
            Assert.AreEqual(application.Team.Name, model.TeamName);
        }
    }
}

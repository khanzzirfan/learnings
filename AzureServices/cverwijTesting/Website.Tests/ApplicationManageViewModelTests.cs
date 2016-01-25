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
    public class ApplicationManageViewModelTests
    {
        [TestMethod]
        public void ToDalEntity_converts_model_properties_to_DAL_entity()
        {
            // setup
            var application = new ApplicationBuilder().WithName("Name").WithDefaultTeam().Build();
            var model = new ApplicationManageViewModel(application);

            // act
            var result = model.ToDalEntity();

            // verify
            Assert.AreEqual(application.Id, result.Id);
            Assert.AreEqual(application.Name, result.Name);
            Assert.AreEqual(application.Description, result.Description);
            Assert.AreEqual(application.TeamId, result.TeamId);
        }
    }
}

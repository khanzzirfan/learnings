using ChristiaanVerwijs.MvcSiteWithEntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChristiaanVerwijs.MvcSiteWithEntityFramework.WebSite.Models;

namespace ChristiaanVerwijs.MvcSiteWithEntityFramework.WebSite.Controllers
{
    public class ApplicationController : ControllerBase
    {
        internal readonly IApplicationRepository applicationRepository;
        internal readonly ITeamRepository teamRepository;

        public ApplicationController(IApplicationRepository applicationRepository, ITeamRepository teamRepository)
        {
            this.applicationRepository = applicationRepository;
            this.teamRepository = teamRepository;
        }

        public ActionResult Index()
        {
            var viewModel = new ApplicationListViewModel();
            var applications = applicationRepository.GetAll().OrderBy(p => p.Name);
            return View(new ApplicationListViewModel(applications));
        }

        public ActionResult Create()
        {
            LoadTeamsInViewData();
            return View(new ApplicationManageViewModel());
        }

        [HttpPost]
        public ActionResult Create(ApplicationManageViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var application = model.ToDalEntity();
                    applicationRepository.InsertAndSubmit(application);

                    base.SetSuccessMessage("The application [{0}] has been created.", application.Name);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    base.SetErrorMessage("Whoops! Couldn't create the new application. The error was [{0}]", ex.Message);
                }
            }

            LoadTeamsInViewData();
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var application = applicationRepository.GetById(id);

            if (application == null)
            {
                base.SetErrorMessage("Application with Id [{0}] does not exist", id.ToString());
                return RedirectToAction("Index");
            }

            LoadTeamsInViewData(application.TeamId);
            return View(new ApplicationManageViewModel(application));
        }

        [HttpPost]
        public ActionResult Edit(ApplicationManageViewModel model)
        {
            if (ModelState.IsValid)
            {
                var application = applicationRepository.GetById(model.Id);
                if (application == null) { throw new ArgumentException(string.Format("Application with Id [{0}] does not exist", model.Id)); }

                try
                {
                    model.ToDalEntity(application);
                    applicationRepository.UpdateAndSubmit(application);

                    base.SetSuccessMessage("The application [{0}] has been updated.", application.Name);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    base.SetErrorMessage("Whoops! Couldn't update the application. The error was [{0}]", ex.Message);
                }
            }

            LoadTeamsInViewData();
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var application = applicationRepository.GetById(id);

            if (application == null)
            {
                base.SetErrorMessage("Application with Id [{0}] does not exist", id.ToString());
                return RedirectToAction("Index");
            }

            return View(new ApplicationViewModel(application));
        }

        [HttpPost]
        public ActionResult Delete(ApplicationViewModel model)
        {
            var application = applicationRepository.GetById(model.Id);
            if (application == null) { throw new ArgumentException(string.Format("Application with Id [{0}] does not exist", model.Id)); }

            try
            {
                applicationRepository.SoftDeleteAndSubmit(application);

                base.SetSuccessMessage("The application has been (soft) deleted.");
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                base.SetErrorMessage("Whoops! Couldn't delete the application. The error was [{0}]", ex.Message);
            }

            return View(model);
        }

        #region Private Helpers
        private void LoadTeamsInViewData(object selectedValue = null)
        {
            var teams= teamRepository.GetAll().OrderBy(p => p.Name);
            ViewBag.TeamId = new SelectList(teams, "Id", "Name", selectedValue);
        }
        #endregion
    }
}

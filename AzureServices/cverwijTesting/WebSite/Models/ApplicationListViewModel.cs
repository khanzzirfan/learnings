using ChristiaanVerwijs.MvcSiteWithEntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChristiaanVerwijs.MvcSiteWithEntityFramework.WebSite.Models
{
    public class ApplicationListViewModel
    {
        public ApplicationListViewModel()
        {
            this.Applications = new List<ApplicationViewModel>();
        }

        public ApplicationListViewModel(IEnumerable<Application> applications)
        {
            this.Applications = new List<ApplicationViewModel>();

            foreach (var application in applications)
            {
                this.Applications.Add(new ApplicationViewModel(application));
            }
        }

        public List<ApplicationViewModel> Applications { get; set; }
    }
}

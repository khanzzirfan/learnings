using ChristiaanVerwijs.MvcSiteWithEntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChristiaanVerwijs.MvcSiteWithEntityFramework.WebSite.Models
{
    public class ApplicationManageViewModel : ApplicationViewModel
    {
        public ApplicationManageViewModel()
            : base()
        {
        }
        public ApplicationManageViewModel(Application application)
            : base(application)
        {
        }

        public Application ToDalEntity()
        {
            return ToDalEntity(new Application());
        }

        public Application ToDalEntity(Application application)
        {
            application.Id = this.Id;
            application.Name = this.Name;
            application.Description = this.Description;
            application.TeamId = this.TeamId;
            return application;
        }

    }
}

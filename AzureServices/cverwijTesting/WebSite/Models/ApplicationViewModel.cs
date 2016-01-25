using ChristiaanVerwijs.MvcSiteWithEntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChristiaanVerwijs.MvcSiteWithEntityFramework.WebSite.Models
{
    public class ApplicationViewModel
    {
        public ApplicationViewModel()
        {
        }

        public ApplicationViewModel(Application application)
        {
            this.Id = application.Id;
            this.Name = application.Name;
            this.Description = application.Description;
            this.TeamName = application.Team != null ? application.Team.Name : string.Empty;
            this.TeamId = application.TeamId;
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        public string TeamName { get; set; }
        public string Description { get; set; }

        [Required(ErrorMessage = "Team is required")]
        public int TeamId { get; set; }
    }
}

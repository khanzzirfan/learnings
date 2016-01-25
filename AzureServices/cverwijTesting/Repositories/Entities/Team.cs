using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ChristiaanVerwijs.MvcSiteWithEntityFramework.Repositories
{
    public class Team
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? Deleted { get; set; }

        // navigation properties
        public virtual ICollection<Application> Applications { get; set; }
    }
}

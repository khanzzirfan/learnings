using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ChristiaanVerwijs.MvcSiteWithEntityFramework.Repositories
{
    public class Application
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public virtual Team Team { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? Deleted { get; set; }

        [ForeignKey("Team")]
        public int TeamId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RepositoryIK.Tests.Helpers
{
    public class TestEntity
    {
       [Key]
        public int Id { get; set; }
        public DateTime? Deleted { get; set; } 
        public string name { get; set; }
    }
}

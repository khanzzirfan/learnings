using Codenutz.XFLabs.Basics.Contracts;
using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codenutz.XFLabs.Basics.DAL
{
    public class HomeDAO:IBusinessEntity
    {
        public HomeDAO()
        {
        }

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [MaxLength(50)]
        public string SearchBy { get; set; }
        public string SearchByDescription { get; set; }
        public string Image { get; set; } 
    }







}

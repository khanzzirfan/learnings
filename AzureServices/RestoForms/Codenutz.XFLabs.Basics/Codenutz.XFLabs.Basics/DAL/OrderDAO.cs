using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Codenutz.XFLabs.Basics.Contracts;
using SQLite.Net.Attributes;


namespace Codenutz.XFLabs.Basics.DAL
{
    public class OrderDAO : IBusinessEntity
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [Indexed]
        public int RestaurantId {get;set;}

        public DateTime Date { get; set; }

        public bool OrderComplete { get; set; }
    }
}

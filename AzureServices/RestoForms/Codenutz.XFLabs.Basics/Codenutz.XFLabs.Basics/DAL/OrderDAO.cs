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
        public int StoreId {get;set;}

        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string PickupTime { get; set; }
        public string Phone { get; set; }
        public decimal Amount { get; set; }
        public string Comment { get; set; }
        
        //Completed placing the order; Hence no longer show in menu items quantity
        public bool IsOrderComplete { get; set; }

    }
}

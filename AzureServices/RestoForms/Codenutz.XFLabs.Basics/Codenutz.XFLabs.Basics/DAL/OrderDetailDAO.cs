using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Codenutz.XFLabs.Basics.Contracts;
using SQLite.Net.Attributes;


namespace Codenutz.XFLabs.Basics.DAL
{
    public class OrderDetailDAO : IBusinessEntity
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [Indexed]
        public int MenuID { get; set; }
        [Indexed]
        public int RestaurantId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TaxAmount { get; set; }

    }
}

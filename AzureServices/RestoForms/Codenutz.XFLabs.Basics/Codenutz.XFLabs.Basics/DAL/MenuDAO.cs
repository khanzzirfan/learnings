using Codenutz.XFLabs.Basics.Contracts;
using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codenutz.XFLabs.Basics.DAL
{
    public class MenuDAO : IBusinessEntity
    {

        public MenuDAO()
        {
        }

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public int StoreID { get; set; }
        public int MenuID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string MenuType { get; set; } //Mains/Starter/Dessert/Sides;
        public string MenuCategory { get; set; } //Chicken/Lamb/Sea/Vege;
        public string ThumbUrl { get; set; }
        public string LargeUrl { get; set; }
        public string SmallUrl { get; set; }

        public int QuantityOrdered { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Codenutz.XFLabs.Basics.Model
{
    public class DisplayMenu
    {
        public string MenuCategory { get; set; }
        public List<Menu> MenuList { get; set; }
    }

    public class Menu
    {
        public int ID { get; set; }
        public decimal MenuID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string MenuType { get; set; } //Mains/Starter/Dessert/Sides;
        public string MenuCategory { get; set; } //Chicken/Lamb/Sea/Vege;
        public string ThumbUrl { get; set; }
        public string LargeUrl { get; set; }
        public string SmallUrl { get; set; }
        public decimal QuantityOrdered { get; set; }
    }

}

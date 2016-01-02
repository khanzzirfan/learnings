using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codenutz.XFLabs.Basics.Model
{
    public class OrderDetails
    {
        public OrderDetails()
        {
        }

        public int ID { get; set; }
        public int MenuID { get; set; }
        public string MenuName { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        
        public decimal TaxAmount { get; set; }

        public string TotalAmount
        {
            get
            {
                return string.Format("{0:C}", Quantity * Price);
            }
        }

        public string DisplayOrderQuantity
        {
            get { return string.Format("{0} X {1:C}", Quantity, Price); }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codenutz.XFLabs.Basics.Model
{
    public class ReserveTable
    {
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public int Guests { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public string Comment { get; set; }



    }
}

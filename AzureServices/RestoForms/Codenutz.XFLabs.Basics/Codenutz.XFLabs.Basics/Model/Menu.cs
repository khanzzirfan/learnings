using Codenutz.XFLabs.Basics.DAL;
using System;
using System.Collections.Generic;

namespace Codenutz.XFLabs.Basics.Model
{
    public class DisplayMenu
    {
        public string MenuCategory { get; set; }
        public List<MenuDAO> MenuList { get; set; }
    }
    
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XLabs.Platform.Device;

namespace EmpApp2.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }


        public LoginViewModel(Page page)
            : base(page)
        {
            Title = "Employee Roll Check";
        }

        public LoginViewModel(IDevice device)
            : base(device)
        {
            Title = "Employee Roll Check";
        }
        public LoginViewModel()
        {
            Title = "Employee Roll Check";
        }





    }
}

using EmpApp2.Model;
using EmpApp2.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XLabs.Platform.Device;
using System.Collections.ObjectModel;

namespace EmpApp2.ViewModel
{
    public class AdminViewModel : BaseViewModel
    {
        public EmployeeDB EmpDb;
        public EmployeeDetails EmpDetails { get; set; }

        public ObservableCollection<AdminModel> AdminData { get; set; }

        public AdminViewModel(Page page)
            : base(page)
        {
            Title = "Employee Roll Check Admin";
            AdminData = new ObservableCollection<AdminModel>();
            EmpDb = new EmployeeDB();
        }

        public AdminViewModel(IDevice device)
            : base(device)
        {
            Message = String.Format("Hello Xamarin Forms Labs MVVM Basics!! How is your {0} device", device.Manufacturer);
            Title = "Employee Roll Check Admin";
            Message = "Employee Roll Check";
            AdminData = new ObservableCollection<AdminModel>();
        }
        public AdminViewModel()
        {
            Title = "Employee Roll Check Admin";
            Message = "Employee Roll Check";
            AdminData = new ObservableCollection<AdminModel>();
        }


        private Command getAdminData;
        public Command GetAdminData
        {
            get
            {
                return getAdminData ??
                    (getAdminData = new Command(async () => await ExecuteAdminDataCommand(), () => { return !IsBusy; }));
            }
        }

        public async Task ExecuteAdminDataCommand()
        {

            if (IsBusy)
                return;

            IsBusy = true;
            //Delay for 5 seconds
            //await Task.Delay(5000);
            GetAdminData.ChangeCanExecute();
            var showAlert = false;

            try
            {
                AdminData.Clear();
                var empList = GetEmployeeData();
                foreach (var data in empList)
                {
                    AdminData.Add(data);
                }
            }
            catch (Exception ex)
            {
                showAlert = true;
                //Xamarin.Insights.Report(ex);
            }
            finally
            {
                IsBusy = false;
                GetAdminData.ChangeCanExecute();
            }

            if (showAlert)
                await page.DisplayAlert("Uh Oh :(", "Unable to gather Data.", "OK");

        }



        public List<AdminModel> GetEmployeeData()
        {
            var empAdminList = new List<AdminModel>();
            var data = EmpDb.GetEmployeeDetails();
            var list = EmpDb.GetEmployeeLogList();
            foreach (var d in data)
            {
                var lastLogged = list.Where(c => c.EmpId == d.Id).OrderByDescending(c => Convert.ToDateTime(c.LogTime)).FirstOrDefault();
                var time = lastLogged.LogTime;
                var logType = lastLogged.LogType;

                empAdminList.Add(new AdminModel()
                {
                    EmpId = d.Id,
                    LastClockedIn = Convert.ToDateTime(time),
                    LogType = logType,
                    ThumbUrl = d.ThumbUrl,
                    Name = d.Name,
                    Phone= d.Phone,
                });
            }
            
            return empAdminList;
        }

    }
}

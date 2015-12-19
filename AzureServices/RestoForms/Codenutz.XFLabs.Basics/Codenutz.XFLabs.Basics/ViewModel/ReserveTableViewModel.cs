using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Codenutz.XFLabs.Basics.Model;
namespace Codenutz.XFLabs.Basics.ViewModel
{
    public class ReserveTableViewModel : BaseViewModel
    {
        public ReserveTable ReserveTable { get; set; }

        public ReserveTableViewModel(Page page, string restoName)
            : base(page)
        {
            Title = restoName;
            StoreName = restoName;
        }

        Command saveFeedbackCommand;
        public Command SaveFeedbackCommand
        {
            get
            {
                return saveFeedbackCommand ??
                    (saveFeedbackCommand = new Command(async () => await ExecuteSaveFeedbackCommand(), () => { return !IsBusy; }));
            }
        }

        async Task ExecuteSaveFeedbackCommand()
        {
            if (IsBusy)
                return;

            if (string.IsNullOrWhiteSpace(Comment))
            {
                await page.DisplayAlert("Enter Comments", "Please enter some feedback for our team.", "OK");
                return;
            }

            Message = "Submitting feedback...";
            IsBusy = true;
            saveFeedbackCommand.ChangeCanExecute();
            var showAlert = false;
            try
            {
                var obj = new ReserveTable()
                {
                    Comment = this.Comment,
                    Name = this.Name,
                    Date = this.Date,
                    Email = this.Email,
                    Phone = this.Phone,
                    Guests = this.Guests,
                    Time = this.Time,

                };
                var objRead = obj;

                //await dataStore.AddFeedbackAsync(new Feedback
                //{
                //    Text = this.Text,
                //    FeedbackDate = DateTime.UtcNow,
                //    VisitDate = Date,
                //    Rating = Rating,
                //    ServiceType = ServiceType,
                //    StoreName = StoreName,
                //    Name = Name,
                //    PhoneNumber = PhoneNumber,
                //    RequiresCall = RequiresCall,
                //});
            }
            catch (Exception ex)
            {
                showAlert = true;
                //Xamarin.Insights.Report(ex);
            }
            finally
            {
                IsBusy = false;
                saveFeedbackCommand.ChangeCanExecute();
            }

            if (showAlert)
                await page.DisplayAlert("Uh Oh :(", "Unable to save feedback, please try again.", "OK");


            await page.Navigation.PopAsync();

        }


        #region properties
        string name = string.Empty;
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        string email = string.Empty;
        public string Email
        {
            get { return email; }
            set { SetProperty(ref email, value); }
        }

        string phone = string.Empty;
        public string Phone
        {
            get { return phone; }
            set { SetProperty(ref phone, value); }
        }

        string comment = string.Empty;
        public string Comment
        {
            get { return comment; }
            set { SetProperty(ref comment, value); }
        }

        string time = string.Empty;
        public string Time
        {
            get { return time; }
            set { SetProperty(ref time, value); }
        }

        int guests = 0;
        public int Guests
        {
            get { return guests; }
            set
            {
                SetProperty(ref guests, value);
            }
        }


        DateTime date = DateTime.Today;
        public DateTime Date
        {
            get { return date; }
            set
            {
                SetProperty(ref date, value);
            }
        }

        public string StoreName { get; set;}

        #endregion
    }
}

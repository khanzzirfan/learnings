using Codenutz.XFLabs.Basics.DAL;
using Codenutz.XFLabs.Basics.ViewModel;
using Xamarin.Forms;

namespace Codenutz.XFLabs.Basics.View
{
    public partial class Home : ContentPage
    {
        public Home()
        {
            InitializeComponent();
            BindingContext = new HomeViewModel(this);

            ButtonFindStore.Clicked += async (sender, e) =>
            {
                //if (Device.Idiom == TargetIdiom.Tablet || Device.Idiom == TargetIdiom.Desktop)
                //  await Navigation.PushAsync(new StoresTabletPage());
                //else
                await Navigation.PushAsync(new Search());
            };

            ButtonLeaveFeedback.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new Search());
            };
            
        }


        public void OnItemSelected(object sender, ItemTappedEventArgs args)
        {
            var searchOption = args.Item as HomeDAO;
            if (searchOption == null)
                return;

            Navigation.PushAsync(new Search());
            // Reset the selected item
            list.SelectedItem = null;
        }

    }
}

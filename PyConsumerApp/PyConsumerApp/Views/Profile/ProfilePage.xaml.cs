using Plugin.Connectivity;
using PyConsumerApp.ViewModels.Profile;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace PyConsumerApp.Views.Profile
{
    /// <summary>
    /// Page to show the user profile.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProfilePage" /> class.
        /// </summary>
        ProfileViewModel viewModel;
        public ProfilePage()
        {
            InitializeComponent();
            viewModel = new ProfileViewModel();
            //viewModel.Profile = ProfileDataService.Instance.ProfileViewModel.Profile;
            this.BindingContext = viewModel;

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.GetUserProfile();
        }

    }
}
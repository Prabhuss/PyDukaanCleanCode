using Plugin.Connectivity;
using PyConsumerApp.ViewModels.Profile;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace PyConsumerApp.Views.Profile
{
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfileEditPage : ContentPage
    {
        public ProfileEditPage()
        {
            InitializeComponent();
            ProfileViewModel viewModel = new ProfileViewModel();
            this.BindingContext = viewModel;
        }
    }
}
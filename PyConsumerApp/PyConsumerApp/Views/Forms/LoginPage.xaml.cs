using Plugin.Connectivity;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using PyConsumerApp.Controls;
using PyConsumerApp.ViewModels.Forms;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace PyConsumerApp.Views.Forms
{
    /// <summary>
    /// Page to login with user name and password
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginPage" /> class.
        /// </summary>
        public LoginPage()
        {
            InitializeComponent();
            LoginPageViewModel vm = new LoginPageViewModel(Navigation);
            vm.Initailize(this);
            BindingContext = vm;
        }
        public LoginPage(bool SomeError)
        {
            if(SomeError)
            {
                try
                {
                    DependencyService.Get<IToastMessage>().LongTime("Your session has expired. Please relogin");
                }
                catch { }
            }
            InitializeComponent();
            LoginPageViewModel vm = new LoginPageViewModel(Navigation);
            vm.Initailize(this);
            BindingContext = vm;
        }
        protected async override void OnAppearing()
        {
            if (!Application.Current.Properties.ContainsKey("isSmsPermissionAsked"))
            {
                await CheckSmsPermissions();
            }
            if (!Application.Current.Properties.ContainsKey("isCameraPermissionAsked"))
            {
                await CheckCameraPermissions();
            }
            if (!Application.Current.Properties.ContainsKey("isLocationPermissionAsked"))
            {
                await CheckLocationPermissions();
            }
           // App.StartCheckInternet(lbl_NoInternet, this);
        }

        private async Task CheckSmsPermissions()
        {
            PermissionStatus status = await CrossPermissions.Current.CheckPermissionStatusAsync<SmsPermission>();
            if (status != PermissionStatus.Granted)
            {
                status = await CrossPermissions.Current.RequestPermissionAsync<SmsPermission>();
            }/*
            switch (status)
            {
                case PermissionStatus.Denied:
                    await DisplayAlert("INFO", "SMS permissions are revoked for this app. Please enter OTP manually", "Ok");
                    break;
                case PermissionStatus.Disabled:
                    await DisplayAlert("INFO", "SMS permissions are not enabled for this app. Please enter OTP manually", "Ok");
                    break;
                case PermissionStatus.Restricted:
                    await DisplayAlert("INFO", "SMS permissions are restricted for this app. Please enter OTP manually", "Ok");
                    break;
                case PermissionStatus.Unknown:
                    await DisplayAlert("INFO", "SMS permissions are not exist for this app. Please enter OTP manually", "Ok");
                    break;
            }*/
            Application.Current.Properties["isSmsPermissionAsked"] = status.ToString();

        }

        private async Task CheckCameraPermissions()
        {
            PermissionStatus status = await CrossPermissions.Current.CheckPermissionStatusAsync<CameraPermission>();
            if (status != PermissionStatus.Granted)
            {
                status = await CrossPermissions.Current.RequestPermissionAsync<CameraPermission>();
            }
            /*
            switch (status)
            {
                case PermissionStatus.Denied:
                    await DisplayAlert("INFO", "Camera permission is revoked for this app. Please enter OTP manually", "Ok");
                    break;
                case PermissionStatus.Disabled:
                    await DisplayAlert("INFO", "Camera permission is not enabled for this app. Please enter OTP manually", "Ok");
                    break;
                case PermissionStatus.Restricted:
                    await DisplayAlert("INFO", "Camera permission is restricted for this app. Please enter OTP manually", "Ok");
                    break;
                case PermissionStatus.Unknown:
                    await DisplayAlert("INFO", "Camera permission is not exist for this app. Please enter OTP manually", "Ok");
                    break;
            }*/
            Application.Current.Properties["isCameraPermissionAsked"] = status.ToString();
        }

        private async Task CheckLocationPermissions()
        {
            PermissionStatus status = await CrossPermissions.Current.CheckPermissionStatusAsync<LocationWhenInUsePermission>();
            if (status != PermissionStatus.Granted)
            {
                status = await CrossPermissions.Current.RequestPermissionAsync<LocationWhenInUsePermission>();
            }
            switch (status)
            {
                case PermissionStatus.Denied:
                    await DisplayAlert("INFO", "LocationWhenInUse permission is revoked for this app. Please enter OTP manually", "Ok");
                    break;
                case PermissionStatus.Disabled:
                    await DisplayAlert("INFO", "LocationWhenInUse permission is not enabled for this app. Please enter OTP manually", "Ok");
                    break;
                case PermissionStatus.Restricted:
                    await DisplayAlert("INFO", "LocationWhenInUse permission is restricted for this app. Please enter OTP manually", "Ok");
                    break;
                case PermissionStatus.Unknown:
                    await DisplayAlert("INFO", "LocationWhenInUse permission is not exist for this app. Please enter OTP manually", "Ok");
                    break;
            }
            Application.Current.Properties["isLocationPermissionAsked"] = status.ToString();
        }

    }
}
using PyConsumerApp.DataService;
using PyConsumerApp.Models;
using PyConsumerApp.ViewModels;
using PyConsumerApp.Views.Forms;
using PyConsumerApp.Views.Navigation;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using System.Collections.Generic;
using Plugin.Connectivity;
using Plugin.LatestVersion;
using System.Diagnostics;
using PyConsumerApp.Controls;
using Xamarin.Forms.Internals;

namespace PyConsumerApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class App : Application
    {
        public static string BaseImageUrl { get; } = "https://cdn.syncfusion.com/essential-ui-kit-for-xamarin.forms/common/uikitimages/";
        public static string CategoryPicUrl { get; } = "https://getpytaskintg.blob.core.windows.net/productpics";//category images
        public static string product_url { get; } = "https://getpytaskintg.blob.core.windows.net/productpics"; //product image

        public static string profileImage { get; } = "https://getpytaskintg.blob.core.windows.net/productpics/userimage.PNG";


        private const string logIn_Status = "logInStatus";
        private const string securityAccessKey = "securityAccessKey";
        private const string user_PhoneNumber  = "UserPhoneNumber";
        private const string minimumOrderAmount = "minimumOrderAmount";
        private const string merchantid = "merchantid";
        private const string syncFKey = "syncFKey";

        private static Label labelScreen;
        private static bool hasInternet;
        private static Page currentPage;
        private static Timer timer;
        private static bool noInterShow;

        private string _cartItems = "cartitems";
        public VersionAppInfo AppInfo { get; set; }

        // private static string user_PhoneNumber { get; set; }// = "UserPhoneNumber";


        public string CartItems
        {
            get
            {
                if (Properties.ContainsKey(_cartItems))
                    return (string)Properties[_cartItems];
                return null;
            }
            set
            {
                Properties[_cartItems] = value;
            }
        }
        public string SyncF
        {
            get
            {
                return "MjM3MDA4QDMxMzgyZTMxMmUzMFI0YTd3TDF0b2JtUWhJelVlWjRJRGF3Qk1PSDcwUFBBUWxJN3ZITXgybXM9";
            }
        }

        public bool IsLoggedIn
        {
            get
            {
                if (Properties.ContainsKey(logIn_Status))
                    return (bool)Properties[logIn_Status];
                return false;
            }
            set
            {
                Properties[logIn_Status] = value;
            }
        }
        public string UserPhoneNumber
        {
            get
            {
                if (Properties.ContainsKey(user_PhoneNumber))
                    return (string)Properties[user_PhoneNumber];
                return null;
            }
            set
            {
                Properties[user_PhoneNumber] = value;
            }
        }
        public double MinimumOrderAmount
        {
            get
            {
                if (Properties.ContainsKey(minimumOrderAmount))
                    return (double)Properties[minimumOrderAmount];
                return 0;
            }
            set
            {
                Properties[minimumOrderAmount] = value;
            }
        }
        public string SecurityAccessKey
        {
            get
            {
                if (Properties.ContainsKey(securityAccessKey))
                    return (string)Properties[securityAccessKey];
                return null;
            }
            set
            {
                Properties[securityAccessKey] = value;
            }
        }
        public string Merchantid
        {
            get
            {
                if (Properties.ContainsKey(merchantid))
                    return (string)Properties[merchantid];
                //hardcodeMerchantID
                Properties[merchantid] = "2";
                return (string)Properties[merchantid];
            }
            set
            {
                Properties[merchantid] = value;
            }
        }

        public App()
        {
            try
            {
                InitializeComponent();
                Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(SyncF);
                if (!IsLoggedIn)
                {
                    MainPage = new NavigationPage(new LoginPage());
                    BaseViewModel.Navigation = MainPage.Navigation;
                }
                else
                {
                    MainPage = new NavigationPage(new BottomNavigationPage());
                    BaseViewModel.Navigation = MainPage.Navigation;
                }
                DependencyService.Register<MockDataStore>();
                
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while app loading  "+e.Message);
            }
            
        }

        protected override void OnStart()
        {
            AppCenter.Start("android=fea975bc-6fe5-4c13-912a-88aaefdc38a2;" +
                  "uwp={Your UWP App secret here};" +
                  "ios={Your iOS App secret here}",
                  typeof(Analytics), typeof(Crashes));

            if (CrossConnectivity.Current.IsConnected)
            {
                CheckVersion();
            }
            else
            {
                try
                {
                    DependencyService.Get<IToastMessage>().LongTime("No Internet Connection");
                }
                catch { }
            }
            // check version function called
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        async void CheckVersion()
        {
            try
            {
                await Task.Delay(3000);
                AppInfo = new VersionAppInfo();
                VersionApiData VData = await VersionService.Instance.CheckVersion(Merchantid);
                AppInfo = VData.AppInfo;
                var NewVersion = AppInfo.AppVersion;
                var Message = AppInfo.MessageForUpdateVersion;
                var url = AppInfo.PlayStoreURL;
                var UpdateType = AppInfo.UpdateType;

                string installedVersionNumber = CrossLatestVersion.Current.InstalledVersionNumber;
                Debug.WriteLine("Latest Version Number :", installedVersionNumber);
                double previousversion = Double.Parse(installedVersionNumber);
                Debug.WriteLine("Version Number :", previousversion);

                // update is optional
                if ((previousversion < NewVersion) && (UpdateType == "Optional"))
                {
                    var update = await App.Current.MainPage.DisplayAlert("New Version", Message, "Yes", "No");

                    if (update)
                    {
                        Xamarin.Forms.Device.OpenUri(new Uri(url));

                        // await CrossLatestVersion.Current.OpenAppInStore();
                        // 
                    }
                }
                else if ((previousversion < NewVersion) && (UpdateType == "Mandatory"))
                {
                    var update = await App.Current.MainPage.DisplayAlert("New Version", Message, "Yes", "No");

                    if (update)
                    {
                        Xamarin.Forms.Device.OpenUri(new Uri(url));
                        System.Diagnostics.Process.GetCurrentProcess().Kill();
                        // Xamarin.Forms.Device.OpenUri(new Uri("market://details?id=com.getpy.deliver"));

                        //await CrossLatestVersion.Current.OpenAppInStore();
                    }
                    else
                    {
                        //Application.Current.Exit();
                        System.Diagnostics.Process.GetCurrentProcess().Kill();
                    }
                }

                /*try
                {
                    var isLatest = await CrossLatestVersion.Current.IsUsingLatestVersion();

                    if (!isLatest)
                    {
                        var update = await App.Current.MainPage.DisplayAlert("New Version", "There is a new version of this app available. Would you like to update now?", "Yes", "No");

                        if (update)
                        {
                            await CrossLatestVersion.Current.OpenAppInStore();
                        }
                    }*/
            }
            catch (Exception ex)
            {
            }

        }
    }
}

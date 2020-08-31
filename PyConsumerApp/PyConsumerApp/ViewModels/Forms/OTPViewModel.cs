using Plugin.Connectivity;
using PyConsumerApp.Controls;
using PyConsumerApp.DataService;
using PyConsumerApp.Views.Navigation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace PyConsumerApp.ViewModels.Forms
{
    [Preserve(AllMembers = true)]
    public class OTPViewModel : BaseViewModel
    {
        #region Fields
        private string otp;
        private string otpCaption;
        private bool isInvalidOtp = false;
        private INavigation navigation;
        private Dictionary<string, string> loginData;
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the property that bounds with an entry that gets the email ID from user in the login page.
        /// </summary>
        public string OTP
        {
            get
            {
                return this.otp;
            }
            set
            {
                if (this.otp == value)
                {
                    return;
                }
                this.otp = value;
                this.NotifyPropertyChanged();
            }
        }
        public string OtpCaption
        {
            get
            {
                return this.otpCaption;
            }
            set
            {
                if (this.otpCaption == value)
                {
                    return;
                }
                this.otpCaption = value;
                this.NotifyPropertyChanged();
            }
        }

        private bool isError;


        public bool IsError
        {
            get
            {
                return this.isError;
            }

            set
            {
                if (this.isError == value)
                {
                    return;
                }

                this.isError = value;
                this.NotifyPropertyChanged();
            }
        }

        private string invalidError;
        public string InvalidError
        {
            get
            {
                return this.invalidError;
            }

            set
            {
                if (this.invalidError == value)
                {
                    return;
                }

                this.invalidError = value;
                this.NotifyPropertyChanged();
            }
        }


        /// <summary>
        /// Gets or sets a value indicating whether the entered email is valid or invalid.
        /// </summary>
        public bool IsInvalidOtp
        {
            get
            {
                return this.isInvalidOtp;
            }

            set
            {
                if (this.isInvalidOtp == value)
                {
                    return;
                }

                this.isInvalidOtp = value;
                this.NotifyPropertyChanged();
            }
        }
        public INavigation Navigation
        {
            get { return navigation; }
            set { navigation = value; }
        }
        #endregion


        #region Command

        /// <summary>
        /// Gets or sets the command that is executed when the OTP submit button is clicked.
        /// </summary>
        public Command OtpCommand { get; set; }

        private Page page;
        #endregion

        #region constructor
        public OTPViewModel(INavigation _navigation)
        {
            Log.Debug("OTPViewModel", "OTPViewModel is constructor invoked and otpCommand is set");
            this.OtpCommand = new Command(this.OtpClicked);
            navigation = _navigation;
        }
        public void Initialize(object _loginData, Page page)
        {
            if (_loginData != null && _loginData is Dictionary<string, string>)
            {
                loginData = (Dictionary<string, string>)_loginData;
                OtpCaption = loginData["phoneNumber"];
            }
            Log.Debug("OTPViewModel-Initialize", "OTPViewModel is initialized ");
            this.page = page;
        }
        #endregion
        /// <summary>
        /// Invoked when the Log In button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private async void OtpClicked(object obj)
        {
            IsBusy = true;
            if (string.IsNullOrEmpty(OTP))
            {
                InvalidError = "Please enter the OTP first";
                await Task.Delay(100);
                IsBusy = false;
                return;
            }
            if (OTP.Length != 6)
            {
                InvalidError = "Please enter 6 Digit OTP ";
                await Task.Delay(100);
                IsBusy = false;
                return;
            }
            if (CrossConnectivity.Current.IsConnected)
            {
                var app = Application.Current as App;
                try
                {
                    Debug.WriteLine(@"Entered OTP is '" + OTP + "'");
                    IsInvalidOtp = false;

                    //hardcodeMerchantID
                    bool valid = await OTPDataService.Instance.validateOtp(app.Merchantid, loginData["phoneNumber"], OTP);
                    if (valid)
                    {
                        IsInvalidOtp = false;
                        app.IsLoggedIn = true;
                        app.UserPhoneNumber = loginData["phoneNumber"];
                        //hardcodeMerchantID
                        app.Merchantid = app.Merchantid;
                        await Task.Delay(100);
                        Application.Current.MainPage = new NavigationPage(new BottomNavigationPage());
                        BaseViewModel.Navigation = Application.Current.MainPage.Navigation;
                        await Task.Delay(10);
                        IsBusy = false;
                    }
                    else
                    {
                        await Task.Delay(10);
                        // Invalid OTP
                        Debug.WriteLine(@"Invalid OTP");
                        InvalidError = "Please enter the valid OTP ";
                        IsInvalidOtp = true;
                        await Task.Delay(10);
                        IsBusy = false;
                    }
                }
                catch (Exception e)
                {
                    IsInvalidOtp = true;
                    InvalidError = "Something went wrong (OTP Error): " + e.Message;
                    await Task.Delay(100);
                    IsBusy = false;
                }
            }
            else
            {
                try
                {
                    DependencyService.Get<IToastMessage>().ShortTime("No Internet Connection");
                }
                catch { }
                IsBusy = false;
            }

        }

    }
}

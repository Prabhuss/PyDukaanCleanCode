using Plugin.Connectivity;
using PyConsumerApp.Controls;
using PyConsumerApp.DataService;
using PyConsumerApp.ViewModels.Transaction;
using Syncfusion.XForms.Buttons;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace PyConsumerApp.Views.Transaction
{
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CheckoutPage //: ContentPage
    {
        public static string SelectedAddressTagName;
        public CheckoutPageViewModel viewModel;
        public CheckoutPage()
        {
            InitializeComponent();
            var userDataService = ProfileDataService.Instance;
            var cartDataService = CartDataService.Instance;
            var catalogDataService = CatalogDataService.Instance;
            BindingContext = viewModel =new CheckoutPageViewModel(userDataService, cartDataService, catalogDataService);
        }
        private void SfRadioButton_StateChanged(object sender, StateChangedEventArgs e)
        {
            Console.WriteLine("Triggering this function " + sender);
            SfRadioButton sfRadioButton = sender as SfRadioButton;
            SelectedAddressTagName = sfRadioButton.Text.ToLower();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (CrossConnectivity.Current.IsConnected)
            {

            }
            else
            {
                try
                {
                    DependencyService.Get<IToastMessage>().LongTime("No Internet Connection");
                }
                catch { }
            }
            viewModel.FetchAddresses();
            //viewModel.GetPaymentCredentials();
        }

    }
}
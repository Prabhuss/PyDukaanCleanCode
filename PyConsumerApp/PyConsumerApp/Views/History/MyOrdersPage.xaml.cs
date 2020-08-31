using Plugin.Connectivity;
using PyConsumerApp.DataService;
using PyConsumerApp.Models.History;
using PyConsumerApp.ViewModels.History;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace PyConsumerApp.Views.History
{
    
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyOrdersPage : ContentPage
    {
        public MyOrdersPageViewModel viewModels;
        public MyOrdersPage()
        {
            InitializeComponent();
            var myOrdersDataService = MyOrdersDataService.Instance;
            viewModels = new MyOrdersPageViewModel(myOrdersDataService);
            BindingContext = viewModels;
            //getOrders();
        }

        private async void getOrders()
        {
            try
            {
                var myOrdersDataService = MyOrdersDataService.Instance;
                var orderedItem = await myOrdersDataService.GetOrderedItemsAsync();
                if (orderedItem.Data.CustomerInvoiceData != null)
                    (BindingContext as MyOrdersPageViewModel).OrderDetails = new ObservableCollection<CustomerInvoiceDatum>(orderedItem.Data.CustomerInvoiceData);

            }
            catch (Exception ex)
            {
               await DisplayAlert("error", ex.Message, "ok");
            }


        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModels.IsBusy = true;
        }

        private async void SfListView_ItemTapped(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
            var invoicedetails = e.ItemData as CustomerInvoiceDatum;
            await Navigation.PushAsync(new OrderSummary(invoicedetails, viewModels.ProductList));

        }
    }
}
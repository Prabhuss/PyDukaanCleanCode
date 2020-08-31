using Plugin.Connectivity;
using PyConsumerApp.Models.History;
using PyConsumerApp.ViewModels.History;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PyConsumerApp.Views.History
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderSummary : ContentPage
    {
        OrderSummaryViewModel viewModel;
        public OrderSummary()
        {
            InitializeComponent();
        }
        public OrderSummary(CustomerInvoiceDatum InvoiceDetails, ObservableCollection<InvocieLineItem> LineitemFromCloud)
        {
            InitializeComponent();
            BindingContext = viewModel = new OrderSummaryViewModel(InvoiceDetails, LineitemFromCloud);
        }
    }
}
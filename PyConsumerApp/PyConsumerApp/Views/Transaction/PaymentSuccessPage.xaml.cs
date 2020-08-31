
using Plugin.Connectivity;
using PyConsumerApp.Models;
using PyConsumerApp.ViewModels.Transaction;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace PyConsumerApp.Views.Transaction
{
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaymentSuccessPage : ContentPage
    {
        public PaymentSuccessPage(OrderResponse OrderStatusInformation)
        {
            BindingContext = new PaymentViewModel(OrderStatusInformation);
            InitializeComponent();
        }
    }
}
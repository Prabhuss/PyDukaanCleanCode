using Plugin.Connectivity;
using PyConsumerApp.ViewModels.Transaction;

using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace PyConsumerApp.Views.Transaction
{
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DeliveryView //: ContentPage
    {
        CheckoutPageViewModel vm;
        public DeliveryView()
        {
            InitializeComponent();
        }

    }
}
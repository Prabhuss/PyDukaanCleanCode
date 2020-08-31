
using Plugin.Connectivity;
using Syncfusion.XForms.Buttons;
using System;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace PyConsumerApp.Views.Transaction
{
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaymentView //: ContentPage
    {
        public PaymentView()
        {
            InitializeComponent();
        }

        private void PWC_StateChanged(object sender, StateChangedEventArgs e)
        {

        }
    }
}
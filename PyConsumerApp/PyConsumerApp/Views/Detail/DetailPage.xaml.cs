using Microsoft.AppCenter.Analytics;
using Plugin.Connectivity;
using PyConsumerApp.Models;
using PyConsumerApp.ViewModels.Detail;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace PyConsumerApp.Views.Detail
{
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailPage : ContentPage
    {
        //  public DetailPage()
        public DetailPage(Product selectedProduct)
        {
            try
            {
                var app = App.Current as App;
                InitializeComponent();
                BindingContext = new DetailPageViewModel(selectedProduct);
                Analytics.TrackEvent("Product_Clicked", new Dictionary<string, string> {
                            { "MerchantBranchId", app.Merchantid},
                            { "UserPhoneNumber", app.UserPhoneNumber},
                            { "ProductName", selectedProduct.productName},
                            { "ProductId", selectedProduct.CitrineProdId.ToString()}
                            });
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                 //DisplayAlert("Error", ex.Message, "OK");
            }
            
        }
    }
}
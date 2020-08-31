using PyConsumerApp.DataService;
using PyConsumerApp.Models;
using PyConsumerApp.ViewModels.Catalog;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;
using PyConsumerApp.DataService;
using System;
using Plugin.Permissions;
using Plugin.Connectivity;
using PyConsumerApp.Controls;
using PyConsumerApp.ViewModels.Transaction;
using PermissionStatus = Plugin.Permissions.Abstractions.PermissionStatus;

namespace PyConsumerApp.Views.Catalog
{
    /// <summary>
    /// The Category Tile page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoryTilePage
    {
        //private CategoryPageViewModel vm;
        private SubCategoryPageViewModel vm;
        private string Latitude;
        private string Longitude;
        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryTilePage" /> class.
        /// </summary>
        public CategoryTilePage()
        {
            InitializeComponent();
            //vm = new CategoryPageViewModel();
            vm = new SubCategoryPageViewModel();
            this.BindingContext = vm;
            new Task(async () => {
                await populateData();
            }).Start();
        }
        async private Task populateData()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                ObservableCollection<SubCategory> categories = await CategoryDataService.Instance.PopulateData();
                if (categories != null)
                {
                    vm.Categories = categories;
                }
                try
                {
                    var app = App.Current as App;
                    Merchantdata MerchantSettingDetails = await CategoryDataService.Instance.GetMerchantSettings("Amount");
                    if (MerchantSettingDetails != null)
                    {
                        if(MerchantSettingDetails.SettingIsActive.ToLower()=="yes")
                            app.MinimumOrderAmount = Double.Parse(MerchantSettingDetails.SettingValue);
                    }
                    bool DistanceCalculated = await DistanceCheck();
                }
                catch (Exception e)
                {
                    string a = e.Message;
                    await Task.Delay(1000);
                    //await DisplayAlert("Error", "Somthing went wrong while accessing Merchant details", "Ok");
                }

            }
            else
            {
                try
                {
                    DependencyService.Get<IToastMessage>().LongTime("No Internet Connection");
                }
                catch { }
            }
        }

        async private Task<bool> DistanceCheck()
        {
            var app = App.Current as App;
            bool CordinatesFlag = await getCordinatesAsync();
            if (CordinatesFlag)
            {
                double Distance = Double.Parse(await CategoryDataService.Instance.CalculateDistance(Latitude, Longitude));
                if (Distance > 0)
                {
                    Merchantdata MerchantSettingDetails = await CategoryDataService.Instance.GetMerchantSettings("Distance");
                    if (MerchantSettingDetails != null)
                    {
                        if(MerchantSettingDetails.SettingIsActive.ToLower() =="yes")
                            if ((Double.Parse(MerchantSettingDetails.SettingValue) - Distance) < 0)
                                await DisplayAlert("Message", MerchantSettingDetails.SettingMessage, "Ok");
                        return true;
                    }
                }
            }
                return false;
        }

        public async Task<bool> getCordinatesAsync()
        {
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();
                if (location != null)
                {
                    Latitude = location.Latitude.ToString();
                    Longitude = location.Longitude.ToString();
                    return true;
                }
                else
                { 
                    //await DisplayAlert("Location Error(102)", "We are facing problem in accessing your Current location", "Ok");
                    return false;
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            { 
                //await DisplayAlert("Location Error(103)", "We are facing problem in accessing your Current location", "Ok");
                return false;
            }
            catch (PermissionException pEx)
            { 
                //await DisplayAlert("Location Error(104)", "We are facing problem in accessing your Current location", "Ok");
                return false;
            }
            catch (System.Exception ex)
            { 
                //await DisplayAlert("Location Error(105)", "We are facing problem in accessing your Current location", "Ok");
                return false;
            }
        }

    }
}
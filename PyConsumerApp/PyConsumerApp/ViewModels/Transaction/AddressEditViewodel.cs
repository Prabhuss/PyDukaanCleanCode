using Plugin.Connectivity;
using Plugin.Permissions;
using PyConsumerApp.Controls;
using PyConsumerApp.DataService;
using PyConsumerApp.Models;
using System;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using PermissionStatus = Plugin.Permissions.Abstractions.PermissionStatus;

namespace PyConsumerApp.ViewModels.Transaction
{

    [Preserve(AllMembers = true)]
    [DataContract]
    class AddressEditViewodel : BaseViewModel
    {
        public Command ChangeAddressInfo { get; set; }
        public Command UseMyLocationCommand { get; set; }
        
        public Address customerAddress;

        public ObservableCollection<string> addressTypesList;
        public ObservableCollection<string> AddressTypesList
        {
            get { return addressTypesList; }
            set
            {
                if (addressTypesList != value)
                {
                    addressTypesList = value;
                    OnPropertyChanged();
                }
            }
        }
        
        string _addressLocationMessage;
        [DataMember(Name = "AddressLocationMessage")]
        public string AddressLocationMessage
        {
            get { return _addressLocationMessage; }
            set
            {
                if (_addressLocationMessage != value)
                {
                    _addressLocationMessage = value;
                    OnPropertyChanged();
                }
            }
        }

        string selectedAddressType;
        [DataMember(Name = "selectedAddressType")]
        public string SelectedAddressType
        {
            get { return selectedAddressType; }
            set
            {
                if (selectedAddressType != value)
                {
                    selectedAddressType = value;
                    OnPropertyChanged();
                }
            }
        }

        [DataMember(Name = "customerAddress")]
        public Address CustomerAddress
        {
            get => customerAddress;

            set
            {
                if (customerAddress == value) return;
                customerAddress = value;
                NotifyPropertyChanged();
            }
        }

        private bool _locationCheckValue;
        [DataMember(Name = "LocationCheckValue")]
        public bool LocationCheckValue
        {
            get => _locationCheckValue;

            set
            {
                if (_locationCheckValue == value) return;
                _locationCheckValue = value;
                NotifyPropertyChanged();
            }
        }
        public AddressEditViewodel()
        {
            customerAddress = new Address();
            addressTypesList = new ObservableCollection<string>();
            addressTypesList.Add("Office");
            addressTypesList.Add("Home");
            addressTypesList.Add("Other");
            selectedAddressType = "";
            SetMessage();
            ChangeAddressInfo = new Command(this.ChangeAddress_Clicked);
        }

        private Command backButtonCommand;
        [DataMember(Name = "backButtonCommand")]
        public Command BackButtonCommand => backButtonCommand ?? (backButtonCommand = new Command(BackButtonClicked));

        private async void BackButtonClicked(object obj)
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }


        private async void UseMyLocation_Clicked()
        {
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();
                if (location != null)
                {
                    CustomerAddress.Latitude = location.Latitude.ToString();
                    CustomerAddress.Longitude = location.Longitude.ToString();
                }
                else
                {
                    DependencyService.Get<IToastMessage>().LongTime("Error L01: Unable to fetch Current location");
                    return;
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                DependencyService.Get<IToastMessage>().LongTime("Error L02: Location Feature is not supported by your device.");
                return;
            }
            catch (PermissionException pEx)
            {
                DependencyService.Get<IToastMessage>().LongTime("Error L03: Seems like your GPS is OFF.");
                return;
            }
            catch (System.Exception ex)
            {
                DependencyService.Get<IToastMessage>().LongTime("Error L04: Unable to fetch Current Location");
                return;
            }
        }
        private async void ChangeAddress_Clicked(object obj)
        {
            if (CustomerAddress.FirstName == null || CustomerAddress.FirstName.Replace(" ","") == "" ||
                CustomerAddress.Address2 == null || CustomerAddress.Address2.Replace(" ", "") == "" ||
                CustomerAddress.TagName == null || CustomerAddress.TagName.Replace(" ", "") == "" ||
                CustomerAddress.Address1 == null || CustomerAddress.Address1.Replace(" ", "") == "" ||
                CustomerAddress.PostalCodeZipCode == null || CustomerAddress.PostalCodeZipCode.Replace(" ", "") == "")
            {
                await Application.Current.MainPage.DisplayAlert("Fields Empty Error", "Please fill all the Mandatory fields", "Ok");
                return;
            }


            if (CrossConnectivity.Current.IsConnected)
            {
                try
                {
                    if (LocationCheckValue)
                    {
                        bool PermissionForLocation = await CheckLocationPermissions();
                        if (PermissionForLocation)
                            UseMyLocation_Clicked();
                    }
                    await Task.Delay(1000);
                    bool resonse = await CartDataService.Instance.SaveAddressInfo(CustomerAddress);
                    if (resonse == true)
                    {
                        DependencyService.Get<IToastMessage>().LongTime("Address changed successfully");
                        await Application.Current.MainPage.Navigation.PopAsync();
                    }
                    else
                    {
                        DependencyService.Get<IToastMessage>().LongTime("Error AD01: Something went wrong while changing the address details");
                    }
                }
                catch (Exception e)
                {
                    await Application.Current.MainPage.DisplayAlert("Error AD02", e.Message, "OK");
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
        public async void SetMessage()
        {
            Merchantdata MerchantSettingDetails = await CategoryDataService.Instance.GetMerchantSettings("LocationMessage");
            if (MerchantSettingDetails != null)
            {
                if (MerchantSettingDetails.SettingIsActive.ToLower() == "yes")
                {
                    AddressLocationMessage = MerchantSettingDetails.SettingMessage;
                }
            }
        }

        private async Task<bool> CheckLocationPermissions()
        {
            try
            {
                PermissionStatus status = await CrossPermissions.Current.CheckPermissionStatusAsync<LocationWhenInUsePermission>();
                if (status != PermissionStatus.Granted)
                {
                    status = await CrossPermissions.Current.RequestPermissionAsync<LocationWhenInUsePermission>();
                    if (status != PermissionStatus.Granted)
                        return true;
                    else
                        return false;
                }
                else
                {
                    return true;
                }
            }
            catch(Exception e)
            {
                //await Application.Current.MainPage.DisplayAlert("Error LP01", e.Message, "OK");
                return false;
            }
        }
    }
}

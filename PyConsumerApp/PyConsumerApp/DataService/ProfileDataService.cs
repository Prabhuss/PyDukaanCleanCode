using PyConsumerApp.Models;
using PyConsumerApp.ViewModels.Profile;
using Syncfusion.DataSource.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;


namespace PyConsumerApp.DataService
{
    [Preserve(AllMembers = true)]
    public class ProfileDataService : BaseService
    {
        private static ProfileDataService instance;
        private ProfileViewModel profileViewModel;
        public static ProfileDataService Instance => instance ?? (instance = new ProfileDataService());
        public ProfileViewModel ProfileViewModel =>
            this.profileViewModel ??
            (this.profileViewModel = PopulateData<ProfileViewModel>("profile.json"));
            
        private static T PopulateData<T>(string fileName)
        {
            var file = "PyConsumerApp.Data." + fileName;

            var assembly = typeof(App).GetTypeInfo().Assembly;
            T obj;

            using (var stream = assembly.GetManifestResourceStream(file))
            {
                var serializer = new DataContractJsonSerializer(typeof(T));
                obj = (T)serializer.ReadObject(stream);
            }
            return obj;
        }
        public async Task<bool> SaveCustomerInfo(CustomerProfile Profile)
        {
            var app = App.Current as App;
            try
            {
                Dictionary<string, object> payload = new Dictionary<string, object>();
                payload.Add("access_key", app.SecurityAccessKey);
                payload.Add("phone_number", app.UserPhoneNumber);
                payload.Add("secondphone_number", Profile.SecondaryPhone);
                payload.Add("merchant_id", app.Merchantid);
                payload.Add("first_name", Profile.FirstName);
                payload.Add("last_name", Profile.LastName);
                payload.Add("device", "");
                payload.Add("latitude", "");
                payload.Add("longitude", "");
                payload.Add("email_id", Profile.Email);
                payload.Add("address1", "");
                payload.Add("address2", "");
                payload.Add("city", Profile.City);
                payload.Add("state", Profile.State);
                payload.Add("country", Profile.Country);
                AddressListResponse<Dictionary<string, object>> response = await this.Post<AddressListResponse<Dictionary<string, object>>>(this.getAuthUrl("setcustInfo"), payload, null);
                if (response.Status.ToLower() == "success")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public async Task<CustomerProfile> GetUserInfo()
        //public async Task<ObservableCollection<CustomerProfile>> GetUserInfo()
        // public async Task<List<string>> GetUserInfo()
        {
            try
            {
                var app = App.Current as App;
                Dictionary<string, string> payload = new Dictionary<string, string>();
                payload.Add("access_key", app.SecurityAccessKey);
                payload.Add("merchant_id", app.Merchantid);
                payload.Add("phone_number", app.UserPhoneNumber);
                CustomerProfile robject = await this.Get<CustomerProfile>(this.getAuthUrl("getcustInfo"), payload, null);
                if (robject != null)
                {
                    return robject;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public async Task<List<Address>> GetAddresses()

        public async Task<ObservableCollection<Address>> GetAddresses()
        {
            //List<Address> Addresses = null;
            var app = Application.Current as App;
            try
            {
                Dictionary<string, object> payload = new Dictionary<string, object>();
                payload.Add("merchant_id", app.Merchantid);
                payload.Add("phone_number", app.UserPhoneNumber);
                payload.Add("access_key", app.SecurityAccessKey);
                AddressListResponse<Address> robject = await this.Post<AddressListResponse<Address>>(this.getAuthUrl("getCustomerAddress"), payload, null);
                if (robject.Status.ToLower() == "success")
                {
                    return robject.Data;
                }
                else
                {
                    return null;
                }

                /* Addresses = new List<Address>
                 {
                     new Address
                     {
                         Name = "Samar Jeet",
                         MobileNo = "9706821681",
                         DoorNo = "123",
                         Area = "Sarjapur",
                         City = "Bangalore",
                         State = "Karnataka",
                         Country = "India",
                         PostalCode = "560035",
                         AddressType = "Home"
                     },
                     new Address
                     {
                         Name = "Samar Jeet",
                         MobileNo = "9706821681",
                         DoorNo = "123",
                         Area = "Sarjapur",
                         City = "Bangalore",
                         State = "Karnataka",
                         Country = "India",
                         PostalCode = "560035",
                         AddressType = "Office"
                     }
                 };*/
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //return await Task.FromResult(Addresses);
        }

    }
    [DataContract]
    public class AddressListResponse<T>
    {
        [DataMember(Name = "status")]
        public string Status;
        [DataMember(Name = "data")]
        public ObservableCollection<T> Data;

    }
}

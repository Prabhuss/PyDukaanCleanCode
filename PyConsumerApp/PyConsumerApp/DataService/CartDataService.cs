using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using Microsoft.AppCenter.Analytics;
using PyConsumerApp.Models;
using PyConsumerApp.Models.History;
using PyConsumerApp.ViewModels.Bookmarks;
using Xamarin.Forms.Internals;

namespace PyConsumerApp.DataService
{
    /// <summary>
    /// Data service to load the data from json file.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class CartDataService : BaseService
    {
        #region fields

        private static CartDataService instance;

        private CartPageViewModel cartPageViewModel;

        private readonly List<UserCart> cartItems = new List<UserCart>();
        

        private readonly List<UserCart> orderedItems = new List<UserCart>();
        //private readonly CartDataService cartDataService;

        #endregion

        #region Constructor

        /// <summary>
        /// Creates an instance for the <see cref="CartDataService"/> class.
        /// </summary>
        private CartDataService()
        {
            
        }

        #endregion

        #region Properties


        
        /// <summary>
        /// Gets an instance of the <see cref="CartDataService"/>.
        /// </summary>
        public static CartDataService Instance => instance ?? (instance = new CartDataService());




        /// <summary>
        /// Gets or sets the value of cart page view model.
        /// </summary>
        public CartPageViewModel CartPageViewModel =>
            (this.cartPageViewModel = PopulateData<CartPageViewModel>("ecommerce.json"));

        #endregion

        #region Methods

        /// <summary>
        /// Populates the data for view model from json file.
        /// </summary>
        /// <typeparam name="T">Type of view model.</typeparam>
        /// <param name="fileName">Json file to fetch data.</param>
        /// <returns>Returns the view model object.</returns>
        /// 

        public async Task<bool> SaveAddressInfo(Address Profile)
        {
            var app = App.Current as App;
            Dictionary<string, object> payload = new Dictionary<string, object>();
            payload.Add("access_key", app.SecurityAccessKey);
            payload.Add("merchant_id", app.Merchantid);
            payload.Add("phone_number", app.UserPhoneNumber); 
            payload.Add("secondPhone_number", Profile.AlternatePhone);
            payload.Add("address1", Profile.Address1);
            payload.Add("address2", Profile.Address2);
            payload.Add("longitude", Profile.Longitude);
            payload.Add("latitude", Profile.Latitude);
            payload.Add("tag_name", Profile.TagName);
            payload.Add("first_name", Profile.FirstName);
            payload.Add("society_buildingNo", Profile.SocietyBuildingNo);
            payload.Add("flatno_doorno", Profile.FlatNoDoorNo);
            payload.Add("city", Profile.City);
            payload.Add("state", Profile.State);
            payload.Add("country", Profile.Country);
            payload.Add("area", Profile.Area);
            payload.Add("postalcode_zipcode", Profile.PostalCodeZipCode);
            /*
             {
"merchant_id":"180",
"phone_number":"9972792530",
"address1":"Silver Spirit tech park, near Infosys",
"address2":"Mysuru",
"longitude":"76.593869",
"latitude":"12.363465",
"tag_name":"Office",
"first_name":"gyvgv",
"society_buildingNo":"biuu5655",
"flatno_doorno":"216",
"city":"gguygug",
"state":"vyug",
"country":"guigu",
"area":"buuguyf",
"postalcode_zipcode":"563333"
}

             */

            AddressListResponse<Dictionary<string, object>> response = await this.Post<AddressListResponse<Dictionary<string, object>>>(this.getAuthUrl("SetCustomerAddress"), payload, null);
            if (response.Status.ToLower() == "success")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
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
        public async Task<Status> UpdateQuantityAsync(int productId, int quantity)
        {
            var status = new Status();
            try
            {
                cartItems.Where(s => s.ProductId == productId).Select(c =>
                {
                    c.TotalQuantity = quantity;
                    return c;
                });
                status.IsSuccess = true;
            }
            catch (Exception ex)
            {
                status.IsSuccess = false;
                status.Message = ex.Message;
            }

            return await Task.FromResult(status);
        }
        public async Task<Status> RemoveCartItemsAsync(int productId)
        {
            var status = new Status();
            try
            {
                var item = cartItems.FirstOrDefault(s => s.ProductId == productId);
                if (item != null) cartItems.Remove(item);

                status.IsSuccess = true;
            }
            catch (Exception ex)
            {
                status.IsSuccess = false;
                status.Message = ex.Message;
            }
            return await Task.FromResult(status);
        }
        public async Task<Status> RemoveCartItemsAsync()
        {
            var status = new Status();
            try
            {
                foreach (var item in cartItems.ToList())
                    orderedItems.Add(item);

                foreach (var item in cartItems.ToList()) cartItems.Remove(item);

                status.IsSuccess = true;
            }
            catch (Exception ex)
            {
                status.IsSuccess = false;
                status.Message = ex.Message;
            }
            return await Task.FromResult(status);
        }
        //public async Task<Status> AddCartItemAsync(int productId)
        public async Task<Status> AddCartItemAsync(Product product)
        {
            var status = new Status();
            var app = App.Current as App;
            try
            {
                //var isProductAlreadyAdded = cartItems.Any(s => s.ProductId == product.Id);
                //var isProductAlreadyAdded = cartItems.Any(s => s.ProductId == product.ProductIdId);
                var isProductAlreadyAdded = cartItems.Any(s => s.ProductId == product.CitrineProdId);
                int qty = 1;
                if (!isProductAlreadyAdded)
                {
                    if(product.TotalQuantity > 0) { qty = (int)product.TotalQuantity; }
                    cartItems.Add(new UserCart
                    {
                        ProductId = product.CitrineProdId,
                        //TotalQuantity = 1,
                        TotalQuantity = qty,
                        Product = product
                    });
                    status.IsSuccess = true;
                    Analytics.TrackEvent("AddToCart_Clicked", new Dictionary<string, string> {
                            { "MerchantBranchId", app.Merchantid},
                            { "UserPhoneNumber", app.UserPhoneNumber},
                            { "ProductId", product.CitrineProdId.ToString()},
                            { "ProductName", product.productName},
                            { "Category",product.Category},
                            { "SubCategory",product.SubCategory},
                            { "Quantity",qty.ToString()}
                            });
                }
                else
                {
                    status.IsSuccess = false;
                }
            }
            catch (Exception ex)
            {
                status.IsSuccess = false;
                status.Message = ex.Message;
            }

            return await Task.FromResult(status);
        }

        public async Task<List<UserCart>> GetCartItemAsync()
        {
            return await Task.FromResult(cartItems);
        }
        public async Task<OrderResponse> SaveOrdereInDb(string Payload)
        {
            OrderResponse robject = await this.Post<OrderResponse>(this.getOrderUrl("CreateOrder"), Payload, null);
            if (robject != null)
            {
                return robject;
            }
            else
            {
                return null;
            }
        }
        public async Task<Dictionary<string,string>> GetPaymentCredentials()
        {
            try
            {
                var app = App.Current as App;
                Dictionary<string, string> payload = new Dictionary<string, string>();
                payload.Add("merchant_id", app.Merchantid);
                payload.Add("phone_number", app.UserPhoneNumber);
                payload.Add("access_key", app.SecurityAccessKey);
                Dictionary<string,string> robject = await this.Get<Dictionary<string, string>>(this.getAuthUrl("getPaymentDetails"), payload, null);
                return robject;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion
    }
}
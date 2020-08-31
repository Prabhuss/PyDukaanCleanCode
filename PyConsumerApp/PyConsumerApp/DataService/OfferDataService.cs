using Microsoft.AppCenter.Analytics;
using PyConsumerApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace PyConsumerApp.DataService
{
    class OfferDataService : BaseService
    {

        private static OfferDataService instance;
        public static OfferDataService Instance => instance ?? (instance = new OfferDataService());

        public async Task<ObservableCollection<OfferData>> PopulateOfferData()
        {
            try
            {
                var app = App.Current as App;
                Dictionary<string, object> payload = new Dictionary<string, object>();
                payload.Add("merchant_id", app.Merchantid);
                payload.Add("phone_number", app.UserPhoneNumber);
                payload.Add("access_key", app.SecurityAccessKey);
                OfferResponse robject = await this.Post<OfferResponse>(this.getAuthUrl("getOfferDetails"), payload, null);
                ObservableCollection<OfferData> OfferList = new ObservableCollection<OfferData>();
                var c = 0;
                foreach (var item in robject.data)
                {
                    OfferList.Add(item);
                }
                Log.Debug("[CategoryDataService]", "Retrieved categories " + robject.data.Count);
                return OfferList;
            }
            catch (Exception e)
            {
                return null;
            }
        }


        public async Task<ObservableCollection<Product>> GetOfferProducts(string OfferCode, int pageNo)
        {
            var app = App.Current as App;
            Dictionary<string, object> payload = new Dictionary<string, object>();
            payload.Add("merchant_id", app.Merchantid);
            payload.Add("offer_code", OfferCode);
            payload.Add("page_size", 10);
            payload.Add("page_number", pageNo);
            payload.Add("phone_number", app.UserPhoneNumber);
            payload.Add("access_key", app.SecurityAccessKey);

            Analytics.TrackEvent("Offer_Clicked", new Dictionary<string, string> {
                            { "MerchantBranchId", app.Merchantid},
                            { "UserPhoneNumber", app.UserPhoneNumber},
                            { "OfferCode", OfferCode}
                            });
            ProductListResponse<Product> robject = await this.Post<ProductListResponse<Product>>(this.getAuthUrl("getOfferProducts"), payload, null);

            if (robject != null)
                if (robject.Status.ToUpper() == "SUCCESS")
                {
                    return robject.Data;
                }
            return null;
        }

    }
}

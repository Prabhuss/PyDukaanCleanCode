using Newtonsoft.Json;
using PyConsumerApp.Controls;
using PyConsumerApp.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PyConsumerApp.DataService
{
    class VersionService : BaseService
    {
        private static VersionService instance;
        public static VersionService Instance => instance ?? (instance = new VersionService());
        public VersionApiData ResponseData { get; set; }
        public async Task<LicenseData> CheckLicense()
        {
            try
            {
                var app = App.Current as App;
                Dictionary<string, dynamic> payload = new Dictionary<string, dynamic>();
                payload.Add("merchant_id", app.Merchantid);
                if(app.Merchantid == null)
                {
                    DependencyService.Get<IToastMessage>().LongTime("No Merchant id Set");
                }
                LicenseDetails response = await this.Post<LicenseDetails>(this.getMerchantUrl("MasterLicenseDetails"), payload, null);
                if (response.Status.ToLower() == "success")
                {
                    return response.Data;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }
        public async Task<VersionApiData> CheckVersion(string merchantId)
        {

            string baseUrl = "https://getpymobileapp.azurewebsites.net/api/v2/auth/";
            string url = string.Format("{0}{1}", baseUrl, "getMessageForVersion");
            using (HttpClient Webclient = new HttpClient())
            {
                var uri = new Uri(url);
                Dictionary<string, dynamic> payload = new Dictionary<string, dynamic>();
                payload.Add("merchant_id", merchantId);
                var json = JsonConvert.SerializeObject(payload);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await Webclient.PostAsync(uri, content);
                if (response.IsSuccessStatusCode)
                {
                    var rcontent = await response.Content.ReadAsStringAsync();
                    try
                    {
                        VersionApiResponse verData = JsonConvert.DeserializeObject<VersionApiResponse>(rcontent);
                        Console.WriteLine("Response of custdetails Status is : " + verData.Status);
                        if (verData.Status.ToLower() != "success")
                        {
                            System.Diagnostics.Debug.WriteLine("[BuildRequestNDisplay] Received non-success " + verData.Status);
                            System.Diagnostics.Debug.WriteLine("[BuildRequestNDisplay] Received Response: " + content);
                            return null;
                        }
                        ResponseData = verData.Data;
                        return ResponseData;
                    }
                    catch (Exception e)
                    {
                        System.Diagnostics.Debug.WriteLine("Error in customer API " + e.Message);
                    }
                }
                return null;
            }
        }
    }
}

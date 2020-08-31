using System;
using System.Threading.Tasks;
using Android.Gms.Extensions;
using Firebase.Iid;
using Xamarin.Forms;

[assembly: Dependency(typeof(PyConsumerApp.Droid.FCMDetails))]


namespace PyConsumerApp.Droid
{
    public class FCMDetails : IFCMDetails
    {
        public async Task<string> GetAppToken()
        {
            IInstanceIdResult result = await FirebaseInstanceId.Instance.GetInstanceId().AsAsync<IInstanceIdResult>();
            int i = 10;
            return result.Token;
        }
    }
}
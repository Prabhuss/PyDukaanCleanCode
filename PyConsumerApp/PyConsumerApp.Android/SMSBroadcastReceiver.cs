using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Auth.Api.Phone;
using Android.Gms.Common.Apis;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;

namespace PyConsumerApp.Droid
{
    [BroadcastReceiver]
    [IntentFilter(new[] { SmsRetriever.SmsRetrievedAction })]
    public class SMSBroadcastReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            if (intent.Action != SmsRetriever.SmsRetrievedAction)
                return;

            var extrasBundleundle = intent.Extras;
            if (extrasBundleundle == null) return;
            var status = (Statuses)extrasBundleundle.Get(SmsRetriever.ExtraStatus);
            switch (status.StatusCode)
            {
                case CommonStatusCodes.Success:
                    // Get SMS message contents
                    var messageContent = (string)extrasBundleundle.Get(SmsRetriever.ExtraSmsMessage);
                    MessagingCenter.Send<string>(messageContent, "ReceivedOTP");
                    // Extract one-time code from the message and complete verification
                    // by sending the code back to your server.
                    //ShowResultOnUI("SMS retrieved: " + messageContent);
                    break;

                case CommonStatusCodes.Timeout:
                    // Waiting for SMS timed out (5 minutes)
                    // Handle the error ...
                    //ShowResultOnUI("Timed Out Error! SMS retrieval failed!");
                    break;
            }
        }
    }
}
using System;
using Android.App;
using Firebase.Iid;
using Android.Util;
using System.Collections.Generic;
using System.Net.Http;

namespace FCMClient
{
    [Service]
    [IntentFilter(new[] { "com.google.firebase.INSTANCE_ID_EVENT" })]
    public class MyFirebaseIIDService : FirebaseInstanceIdService
    {
        const string TAG = "FCM-MyFirebaseIIDService";
        public override void OnTokenRefresh()
        {
            var refreshedToken = FirebaseInstanceId.Instance.Token;
            Log.Debug(TAG, "Refreshed token: " + refreshedToken);
            SendRegistrationToServer(refreshedToken);
        }
        public void SendRegistrationToServer(string token)
        {
            // Add custom implementation, as needed.

        }
    }
}
using Syncfusion.XForms.Android.PopupLayout;
using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Flurry.Analytics;
using Firebase;
using Android.Gms.Common;
using Android.Content;
using Plugin.Connectivity;

namespace PyConsumerApp.Droid
{


    [Activity(Label = "PYDukaan", Icon = "@mipmap/icon", Theme = "@style/MyTheme.Splash", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
   public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        static readonly string TAG = "FCM-MainActivity";

        internal static readonly string CHANNEL_ID = "my_notification_channel";
       
        internal static readonly int NOTIFICATION_ID = 100;
        Toast toast = Toast.MakeText(Application.Context, "Press again to exit", ToastLength.Short);
        bool doubleBackToExitPressedOnce = false;

        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            FirebaseApp.InitializeApp(this);
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            FlurryAgent.Init(Application.Context, "YPZRG9C7CMKFN78RD2BW");
            FlurryAgent.OnStartSession(Application.Context);
            FlurryAgent.SetLogEnabled(true);
            FlurryAgent.SetLogEvents(true);

            base.OnCreate(savedInstanceState);
            if (Intent.Extras != null)
            {
                foreach (var key in Intent.Extras.KeySet())
                {
                    var value = Intent.Extras.GetString(key);
                    Console.WriteLine(TAG, "Key: {0} Value: {1}", key, value);
                }
            }
            /*Log.Debug(TAG, "google app id: " + GetString(Resource.String.google_app_id));*/
            IsPlayServicesAvailable();

            CreateNotificationChannel();
            Firebase.FirebaseApp.InitializeApp(this);
            Rg.Plugins.Popup.Popup.Init(this, savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            SfPopupLayoutRenderer.Init();
            LoadApplication(new App());

            //SMSBroadcastReceiver receiver = new SMSBroadcastReceiver();
            Intent intent = new Intent(this, typeof(SMSBroadcastReceiver));
            StartService(intent);
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        public bool IsPlayServicesAvailable()
        {
            int resultCode = GoogleApiAvailability.Instance.IsGooglePlayServicesAvailable(this);
            if (resultCode != ConnectionResult.Success)
            {
                if (GoogleApiAvailability.Instance.IsUserResolvableError(resultCode))
                {
                    //msgText.Text = GoogleApiAvailability.Instance.GetErrorString(resultCode);
                }
                else
                {
                    //msgText.Text = "This device is not supported";
                    Finish();
                }
                return false;
            }
            else
            {
                //Log.Debug(TAG, "InstanceID token: " + FirebaseInstanceId.Instance.Token);
                //msgText.Text = "Google Play Services is available.";
                return true;
            }
        }

        void CreateNotificationChannel()
        {
            if (Build.VERSION.SdkInt < BuildVersionCodes.O)
            {
                // Notification channels are new in API 26 (and not a part of the
                // support library). There is no need to create a notification
                // channel on older versions of Android.
                return;
            }

            var channel = new NotificationChannel(CHANNEL_ID,
                                                  "FCM Notifications",
                                                  NotificationImportance.Default)
            {

                Description = "Firebase Cloud Messages appear in this channel"
            };

            var notificationManager = (NotificationManager)GetSystemService(Android.Content.Context.NotificationService);
            notificationManager.CreateNotificationChannel(channel);
        }

       /* private void PyamentButton_Click(object sender , EventArgs e)
        {

        }*/

    }
}
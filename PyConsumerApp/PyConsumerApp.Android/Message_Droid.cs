using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using PyConsumerApp.Controls;
using PyConsumerApp.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(Message_Droid))]
namespace PyConsumerApp.Droid
{
    public class Message_Droid : IToastMessage
    {

        public void LongTime(string ToastMessage)
        {
            Toast.MakeText(Android.App.Application.Context, ToastMessage, ToastLength.Long).Show();
        }
        public void ShortTime(string ToastMessage)
        {
            Toast.MakeText(Android.App.Application.Context, ToastMessage, ToastLength.Short).Show();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using OpenBooks_Demo.Droid;
using Xamarin.Forms;
using Android.Content.PM;

[assembly: Xamarin.Forms.Dependency(typeof(OpenBookImp))]
namespace OpenBooks_Demo.Droid
{
    public class OpenBookImp :  Java.Lang.Object, OpenBookInterface
    {
        public OpenBookImp() { }
        public void openBooks()
        {
            var ctx = Forms.Context;

            Intent launchIntent = new Intent();
            launchIntent = ctx.PackageManager.GetLaunchIntentForPackage("com.google.android.apps.books");
            if (launchIntent != null)
            {
                ctx.StartActivity(launchIntent);//null pointer check in case package name was not found
            }
            else
            {
                try
                {
                    ctx.StartActivity(new Intent(Intent.ActionView, Android.Net.Uri.Parse("market://details?id=" + "com.google.android.apps.books")));
                }
                catch (Exception e)
                {
                    ctx.StartActivity(new Intent(Intent.ActionView, Android.Net.Uri.Parse("https://play.google.com/store/apps/details?id=" + "com.google.android.apps.books")));
                }
            }
        }
    }
}
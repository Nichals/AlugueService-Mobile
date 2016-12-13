using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using ZXing;

namespace AlugueServiceMobile.Droid
{
    [Activity(Label = "AlugueService", Icon = "@drawable/Operador_50x50", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
          
            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }
        
    }
}


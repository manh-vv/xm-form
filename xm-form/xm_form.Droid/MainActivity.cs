using Android.App;
using Android.Content.PM;
using Android.OS;
using SQLite.Net.Platform.XamarinAndroid;
using xm_form.Droid.mvv.app.utility;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace xm_form.Droid
{
    [Activity(Label = "xm_form", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Forms.Init(this, bundle);

            var dbPath = FileAccessHelper.GetLocalFilePath("mvvapp.db3");
            LoadApplication(new App(dbPath, new SQLitePlatformAndroid()));
        }
    }
}


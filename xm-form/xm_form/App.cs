using xm_form.mvv.app.screen;
using xm_form.mvv.app.screen.page;
using Xamarin.Forms;
using SQLite.Net.Interop;
using xm_form.mvv.app.utility;

namespace xm_form
{
    public class App : Application
    {
        public App(string dbPath, ISQLitePlatform sqlitePlatform)
        {
            /* initialize data */
            LocalDb.SetDb(dbPath, sqlitePlatform);

            // The root page of your application
            MainPage = new MainPage(new Page0("page 0"));
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

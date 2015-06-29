using Microsoft.Phone.Controls;
using SQLite.Net.Platform.WindowsPhone8;
using xm_form.WinPhone.mvv.app.utility;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WinPhone;

namespace xm_form.WinPhone
{
    public partial class MainPage : FormsApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
            SupportedOrientations = SupportedPageOrientation.PortraitOrLandscape;

            Forms.Init();

            string dbPath = FileAccessHelper.GetLocalFilePath("mvvapp.db3");
            LoadApplication(new xm_form.App(dbPath, new SQLitePlatformWP8()));
        }
    }
}

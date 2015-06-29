using Xamarin.Forms;

namespace xm_form.mvv.app.screen
{
    public class MainPage : NavigationPage
    {
        public MainPage(Page root) : base(root)
        {
			AbsPage.RootPage = root;
        }
    }
}
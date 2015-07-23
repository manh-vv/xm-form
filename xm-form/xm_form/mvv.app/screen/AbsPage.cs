using System.Threading.Tasks;
using xm_form.mvv.app.component;
using Xamarin.Forms;

namespace xm_form.mvv.app.screen
{
    public abstract class AbsPage : ContentPage
    {
        public AbsPage(string pageName)
        {
            PageName = pageName;

			if (_TopBar == null)
				_TopBar = new TopBar();

            Content = new StackLayout
            {
                Children =
                {
                    new Label
                    {
                        Text = PageName,
                        HorizontalOptions = LayoutOptions.CenterAndExpand
                    }
                }
            };
        }

        protected TopBar _TopBar { get; private set; }
        protected string PageName { get; private set; }

        public static Page RootPage { private get; set; }

        protected new View Content
        {
            set
            {
                var content = value;
                content.VerticalOptions = LayoutOptions.FillAndExpand;
                content.HorizontalOptions = LayoutOptions.FillAndExpand;

                var layout = new StackLayout
                {
                    Orientation = StackOrientation.Vertical,
					HorizontalOptions = LayoutOptions.FillAndExpand,
					VerticalOptions = LayoutOptions.FillAndExpand,
                    Children = {_TopBar, content}
                };

                base.Content = layout;
            }
        }
        
        /// <summary>
        /// Go back n page
        /// 
        /// manh.vu
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        protected async Task<Page> NaviagateBack(int n)
        {
            var nPages = RootPage.Navigation.NavigationStack.Count - 2;

            if (n < 1 || n > nPages)
                return null;

            while (--n > 0)
            {
                RootPage.Navigation.RemovePage(Navigation.NavigationStack[nPages--]);
            }

            return await RootPage.Navigation.PopAsync();
        }
    }
}
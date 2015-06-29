using xm_form.mvv.app.component;
using xm_form.mvv.app.utility;
using System;
using xm_form.mvv.app.component.custom;
using Xamarin.Forms;


namespace xm_form.mvv.app.screen.page
{
    /// <summary>
    /// Frame
    /// </summary>
    class Page4 : AbsPage
    {
		private MyButton _btn;

        public Page4(string pageName) : base(pageName)
        {
            _TopBar.LAction = async () =>
            {
                await Navigation.PopAsync();
            };

	        Content = new MyStackLayout
	        {
		        Children =
		        {
			        new CardView(),
			        new CardView(),
			        new CardView()
		        },

				Orientation = StackOrientation.Vertical,
				Spacing = 4,
				Padding = new Thickness(10)
	        };
        }
    }
}

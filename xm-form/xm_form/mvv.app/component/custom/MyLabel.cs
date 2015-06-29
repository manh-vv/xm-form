using xm_form.mvv.app.utility;
using Xamarin.Forms;

namespace xm_form.mvv.app.component.custom
{
	public class MyLabel : Label
	{
		public MyLabel()
		{
			HeightRequest = UiConst.LINE_HEIGHT;
			HorizontalOptions = LayoutOptions.FillAndExpand;
			XAlign = TextAlignment.Center;
			Text = "My label";
		}
	}
}
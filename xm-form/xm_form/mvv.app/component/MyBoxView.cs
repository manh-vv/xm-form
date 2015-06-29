using xm_form.mvv.app.utility;
using Xamarin.Forms;

namespace xm_form.mvv.app.component
{
    public class MyBoxView : BoxView
    {
        public MyBoxView()
        {
            HorizontalOptions = LayoutOptions.FillAndExpand;
            VerticalOptions = LayoutOptions.CenterAndExpand;
            HeightRequest = UiConst.LINE_HEIGHT;
        }
    }
}
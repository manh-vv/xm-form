
using xm_form.mvv.app.utility;
using Xamarin.Forms;

namespace xm_form.mvv.app.component
{
    class MyButton : Button
    {
        public MyButton()
        {
            BorderColor = Color.Fuchsia;
            HeightRequest = UiConst.LINE_HEIGHT;
//            WidthRequest = HeightRequest*1.3;
            BackgroundColor = UiConst.COLOR_DF_BGC;
            BorderRadius = 0;
        }
    }
}

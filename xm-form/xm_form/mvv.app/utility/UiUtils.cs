using Xamarin.Forms.Labs;
using Xamarin.Forms.Labs.Services;

namespace xm_form.mvv.app.utility
{
    public static class UiUtils
    {
	    public static IDevice _iDevice;

	    static UiUtils()
	    {
		    _iDevice = Resolver.Resolve<IDevice>();
	    }

        public static double ScreenWidth
        {
            get { return _iDevice.Display.ScreenWidthInches(); }
        }

        public static double ScreenHeight 
        {
            get { return _iDevice.Display.ScreenHeightInches(); }
        }
    }
}
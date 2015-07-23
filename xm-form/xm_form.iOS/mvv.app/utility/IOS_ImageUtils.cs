using System;
using xm_form.iOS.mvv.app.utility;
using xm_form.mvv.app.utility;

[assembly: Xamarin.Forms.Dependency(typeof(IOS_ImageUtils))]
namespace xm_form.iOS.mvv.app.utility
{
	public class IOS_ImageUtils : IImageUtils
	{
		public async void DownloadImage(string uri, Action<byte[]> whenDone)
		{
			//
		}

		public void ResignImage(byte[] imageData, double width, double height, Action<byte[]> whenDone)
		{
			//
		}
	}
}
using System;
using xm_form.mvv.app.utility;
using xm_form.WinPhone.mvv.app.utility;

[assembly: Xamarin.Forms.Dependency(typeof(Wp_ImageUtils))]
namespace xm_form.WinPhone.mvv.app.utility
{
	public class Wp_ImageUtils : IImageUtils
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
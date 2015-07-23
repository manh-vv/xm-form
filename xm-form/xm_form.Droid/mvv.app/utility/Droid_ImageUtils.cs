using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using Android.Graphics;
using xm_form.Droid.mvv.app.utility;
using xm_form.mvv.app.utility;

[assembly: Xamarin.Forms.Dependency(typeof(Droid_ImageUtils))]
namespace xm_form.Droid.mvv.app.utility
{
	public class Droid_ImageUtils : IImageUtils
	{
		public async void DownloadImage(string uri, Action<byte[]> whenDone)
		{
			var webClient = new WebClient();
			var bytes = await webClient.DownloadDataTaskAsync(new Uri(uri));
			whenDone.Invoke(bytes);
		}

		public void ResignImage(byte[] imageData, double width, double height, Action<byte[]> whenDone)
		{
			// Load the bitmap
			var originalImage = BitmapFactory.DecodeByteArray(imageData, 0, imageData.Length);
			var resizedImage = Bitmap.CreateScaledBitmap(originalImage, (int)width, (int)height, false);
			
			byte[] bytes;

			using (var ms = new MemoryStream())
			{
				resizedImage.Compress(Bitmap.CompressFormat.Jpeg, 100, ms);
				bytes = ms.ToArray();
			}

			whenDone.Invoke(bytes);
		}
	}
}
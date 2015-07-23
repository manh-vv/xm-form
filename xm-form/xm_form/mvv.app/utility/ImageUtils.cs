using System;
using System.Diagnostics;
using xm_form.mvv.app.model;
using Xamarin.Forms;

namespace xm_form.mvv.app.utility
{
	public class ImageUtils
	{
		public static void DownloadImage(string imgUri, Action<byte[]> whenDone)
		{
			LocalDb.SelectOne<CacheImage>("select * from CacheImage where url = ?", new object[] { BuildIndexFromImageUri(imgUri) },
				cacheImage =>
				{
					if (cacheImage != null)
					{
						Debug.WriteLine("---- I found image is cached");
						ScaleLargeImage(cacheImage.imgBytes, whenDone);
						return;
					}

					var imgUtils = DependencyService.Get<IImageUtils>();

					imgUtils.DownloadImage(imgUri, async bytes =>
					{

						ScaleLargeImage(bytes, whenDone);

						// save to db
						cacheImage = new CacheImage
						{
							url = BuildIndexFromImageUri(imgUri),
							imgBytes = bytes,
							lastUpdate = DateUtils.Now
						};

						Debug.WriteLine("---- storing image size = {0} to local db", bytes.Length / 1024);

						var i = await LocalDb.InsertOrReplaceAsync(cacheImage);
						Debug.WriteLine("---- I cache image for next using: " + i);
					});
				}
				);
		}

		private static void ScaleLargeImage(byte[] imgBytes, Action<byte[]> whenDone)
		{
			Debug.WriteLine("---- Byte size = {0}", imgBytes.Length / 1024);
			

			if (imgBytes.Length > (40 * 1024))
			{
				var imgUtils = DependencyService.Get<IImageUtils>();
				imgUtils.ResignImage(imgBytes, 320, 480, whenDone);
			}
			else
			{
				whenDone.Invoke(imgBytes);
			}
		}

		private static string BuildIndexFromImageUri(string imgUri)
		{
			var s = imgUri.Substring(7);
			s = s.Replace('/', '_');

			Debug.WriteLine("---- BuildIndexFromImageUri: " + s);

			return s;
		}
	}
}
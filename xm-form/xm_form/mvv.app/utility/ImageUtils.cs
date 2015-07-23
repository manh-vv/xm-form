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
						whenDone.Invoke(cacheImage.imgBytes);
						return;
					}

					var imgUtils = DependencyService.Get<IImageUtils>();

					imgUtils.DownloadImage(imgUri, async bytes =>
					{
						Debug.WriteLine("---- Byte size = {0}", bytes.Length / 1024);

						if (bytes.Length > (40*1024))
						{
							imgUtils.ResignImage(bytes, 320, 320, whenDone);
						}
						else
						{
							whenDone.Invoke(bytes);
						}

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

		private static string BuildIndexFromImageUri(string imgUri)
		{
			var s = imgUri.Substring(7);
			s = s.Replace('/', '_');

			Debug.WriteLine("---- BuildIndexFromImageUri: " + s);

			return s;
		}
	}
}
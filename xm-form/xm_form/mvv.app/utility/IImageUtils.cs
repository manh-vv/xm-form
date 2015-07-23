using System;

namespace xm_form.mvv.app.utility
{
	public interface IImageUtils
	{
		void DownloadImage(string uri, Action<byte[]> whenDone);
		void ResignImage(byte[] imageData, double width, double height, Action<byte[]> whenDone);
	}
}
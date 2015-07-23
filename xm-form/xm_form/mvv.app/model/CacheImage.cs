using SQLite.Net.Attributes;

namespace xm_form.mvv.app.model
{
	public class CacheImage : DbModel
	{
		[PrimaryKey]
		public string url { get; set; }
		public byte[] imgBytes { get; set; }
		public long lastUpdate { get; set; }
		public long timeout { get; set; }
	}
}
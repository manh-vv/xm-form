using System;

namespace xm_form.mvv.app.utility
{
    public static class DateUtils
    {
        public static long Now
        {
            get { return DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond; }
        }
    }
}
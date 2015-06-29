using System;

namespace xm_form.mvv.app.utility
{
    public class DenyAction<TS, TE>
    {
        private readonly int _denyTime;
        private readonly Action<TS, TE> _mAction;
        private long _last;

        public DenyAction(Action<TS, TE> action, int denyTime = 300)
        {
            _last = 0L;
            _denyTime = denyTime;
            _mAction = action;
        }

        public void OnEvent(TS s, TE e)
        {
            var delta = DateUtils.Now - _last;
            if (delta < _denyTime)
                // ignore this event
                return;

            _last = DateUtils.Now;
            
            if (_mAction != null)
                _mAction.Invoke(s, e);
        }
    }
}
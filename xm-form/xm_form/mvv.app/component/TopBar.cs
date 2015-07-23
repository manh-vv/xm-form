using System;
using xm_form.mvv.app.utility;
using Xamarin.Forms;

namespace xm_form.mvv.app.component
{
    public class TopBar : ContentView
    {
        private readonly MyButton _lBtn;
        private readonly MyButton _rBtn;
        private Action _lAction;
        private Action _rAction;

        public TopBar()
        {
            _lBtn = new MyButton
            {
                Text = "<",
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.FillAndExpand,
                IsVisible = false,
                IsEnabled = false
            };

            _rBtn = new MyButton
            {
                Text = ">",
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.FillAndExpand,
                IsVisible = false,
                IsEnabled = false
            };

            var denyAction = new DenyAction<object, EventArgs>(NavigationEvent, 1000);

            _lBtn.Clicked += denyAction.OnEvent;
            _rBtn.Clicked += denyAction.OnEvent;


            Content = new MyStackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Start,
                Children =
                {
                    _lBtn,
                    new MyBoxView(),
                    _rBtn
                }
            };
            HorizontalOptions = Content.HorizontalOptions;
            VerticalOptions = Content.VerticalOptions;
        }

        public Action LAction
        {
            set
            {
                _lBtn.IsVisible = _lBtn.IsEnabled = true;
                _lAction = value;
            }
        }

        public Action RAction
        {
            set
            {
                _rBtn.IsVisible = _rBtn.IsEnabled = true;
                _rAction = value;
            }
        }

        private void NavigationEvent(object s, EventArgs e)
        {
            if (s == _lBtn && _lAction != null)
            {
                _lAction.Invoke();
            }
            else if (s == _rBtn && _rAction != null)
            {
                _rAction.Invoke();
            }
        }
    }
}
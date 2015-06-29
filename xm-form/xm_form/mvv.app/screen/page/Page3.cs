using xm_form.mvv.app.component;
using xm_form.mvv.app.utility;
using System;


namespace xm_form.mvv.app.screen.page
{
    class Page3 : AbsPage
    {
		private MyButton _btn;

        public Page3(string pageName) : base(pageName)
        {
            _TopBar.LAction = async () =>
            {
                await Navigation.PopAsync();
            };

	        _TopBar.RAction = async () =>
	        {
		        await Navigation.PushAsync(new Page4("Page 4"));
	        };

			_btn = new MyButton {
				Text = "Goto page 1"
			};
			_btn.Clicked += new DenyAction<object, EventArgs> (BtnClicked).OnEvent;

			Content = new MyStackLayout {
				Children = {
					_btn
				}
			};
        }

		private async void BtnClicked (object s, EventArgs e)
		{
		    await NaviagateBack(2);
		}
    }
}

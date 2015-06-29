
namespace xm_form.mvv.app.screen.page
{
    class Page2 : AbsPage
    {
        public Page2(string pageName) : base(pageName)
        {
            _TopBar.LAction = async () =>
            {
                await Navigation.PopAsync();
            };

            _TopBar.RAction = async () =>
            {
                await Navigation.PushAsync(new Page3("page 3"));
            };
        }
    }
}

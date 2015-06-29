namespace xm_form.mvv.app.screen.page
{
    class Page0 : AbsPage
    {
        public Page0(string pageName) : base(pageName)
        {
            _TopBar.RAction = async () =>
            {
                await Navigation.PushAsync(new Page1("page 1"));
            };
        }
    }
}

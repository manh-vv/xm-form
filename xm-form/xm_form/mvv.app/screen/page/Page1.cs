using Xamarin.Forms;

namespace xm_form.mvv.app.screen.page
{
	internal class Page1 : AbsPage
	{
		private Grid _gridLayout;

		public Page1(string pageName) : base(pageName)
		{
			_TopBar.LAction = async () => { await Navigation.PopAsync(); };

			_TopBar.RAction = async () => { await Navigation.PushAsync(new Page2("page 2")); };

			Initialize();
		}

		private void Initialize()
		{
			_gridLayout = new Grid
			{
				VerticalOptions = LayoutOptions.FillAndExpand,
				RowDefinitions =
				{
					new RowDefinition {Height = GridLength.Auto},
					new RowDefinition {Height = GridLength.Auto},
					new RowDefinition {Height = new GridLength(1, GridUnitType.Star)},
					new RowDefinition {Height = new GridLength(100, GridUnitType.Absolute)}
				},
				ColumnDefinitions =
				{
					new ColumnDefinition {Width = GridLength.Auto},
					new ColumnDefinition {Width = new GridLength(1, GridUnitType.Star)},
					new ColumnDefinition {Width = new GridLength(100, GridUnitType.Absolute)}
				}
			};

			_gridLayout.Children.Add(new Label
			{
				Text = "Grid",
				Font = Font.BoldSystemFontOfSize(50),
				HorizontalOptions = LayoutOptions.Center
			}, 0, 3, 0, 1);

			_gridLayout.Children.Add(new Label
			{
				Text = "Autosized cell",
				TextColor = Color.White,
				BackgroundColor = Color.Blue
			}, 0, 1);

			_gridLayout.Children.Add(new BoxView
			{
				Color = Color.Silver,
				HeightRequest = 0
			}, 1, 1);

			_gridLayout.Children.Add(new BoxView
			{
				Color = Color.Teal
			}, 0, 2);

			_gridLayout.Children.Add(new Label
			{
				Text = "Leftover space",
				TextColor = Color.Purple,
				BackgroundColor = Color.Aqua,
				XAlign = TextAlignment.Center,
				YAlign = TextAlignment.Center
			}, 1, 2);

			_gridLayout.Children.Add(new Label
			{
				Text = "Span two rows (or more if you want)",
				TextColor = Color.Yellow,
				BackgroundColor = Color.Navy,
				XAlign = TextAlignment.Center,
				YAlign = TextAlignment.Center
			}, 2, 3, 1, 3);

			_gridLayout.Children.Add(new Label
			{
				Text = "Span 2 columns",
				TextColor = Color.Blue,
				BackgroundColor = Color.Yellow,
				XAlign = TextAlignment.Center,
				YAlign = TextAlignment.Center
			}, 0, 2, 3, 4);

			_gridLayout.Children.Add(new Label
			{
				Text = "Fixed 100x100",
				TextColor = Color.Aqua,
				BackgroundColor = Color.Red,
				XAlign = TextAlignment.Center,
				YAlign = TextAlignment.Center
			}, 2, 3);

			// Accomodate iPhone status bar.
			Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

			// Build the page.
			Content = _gridLayout;
		}
	}
}
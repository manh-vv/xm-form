using System;
using xm_form.mvv.app.utility;
using Xamarin.Forms;

namespace xm_form.mvv.app.component.custom
{
	public class CardView : Frame
	{
		private bool isDown;
		private RelativeLayout _rootLayout;

		public CardView()
		{
			HeightRequest = 6*UiConst.LINE_HEIGHT;
			WidthRequest = 320;
			BackgroundColor = Color.Maroon;
			Padding = new Thickness(2);

			var t = new TapGestureRecognizer();
			t.Tapped += new DenyAction<object, EventArgs>(MAnimation, 800).OnEvent;
			GestureRecognizers.Add(t);

			Content = (_rootLayout = new RelativeLayout()
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				BackgroundColor = UiConst.COLOR_DF_BG
			});

			Content.GestureRecognizers.Add(t);

			// init component
			_rootLayout.Children.Add(new MyLabel
			{
				BackgroundColor = Color.Pink
			}, null, null, null, Constraint.Constant(UiConst.LINE_HEIGHT));
		}

		private async void MAnimation(object s, EventArgs e)
		{
			// ReSharper disable once AssignmentInConditionalExpression
			if (isDown = !isDown)
			{
				await this.RotateYTo(90);
				RotationY = -90;
				await this.RotateYTo(0);
			}
			else
			{
				await this.RotateYTo(-90);
				RotationY = 90;
				await this.RotateYTo(0);
			}
		}
	}
}
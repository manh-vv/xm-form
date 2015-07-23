using System;
using System.Diagnostics;
using System.IO;
using xm_form.mvv.app.component;
using xm_form.mvv.app.component.custom;
using xm_form.mvv.app.utility;
using Xamarin.Forms;

namespace xm_form.mvv.app.screen.page
{
	public class Page0 : AbsPage
	{
		private int _imgCount;

		private readonly MyButton _btnButton = new MyButton
		{
			HorizontalOptions = LayoutOptions.Start,
			Text = "Add Image"
		};

		private readonly MyButton _btnRemobeImage = new MyButton
		{
			HorizontalOptions = LayoutOptions.EndAndExpand,
			Text = "Remove Image"
		};

		private readonly MyStackLayout _layout;

		private readonly MyLabel _myLabel = new MyLabel
		{
			HorizontalOptions = LayoutOptions.CenterAndExpand,
			Text = "Image count: 0"
		};

		public Page0(string pageName) : base(pageName)
		{
			_TopBar.RAction = async () => { await Navigation.PushAsync(new Page1("page 1")); };


			_layout = new MyStackLayout
			{
				Orientation = StackOrientation.Vertical,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				Children =
				{
					new StackLayout
					{
						Orientation = StackOrientation.Horizontal,
						VerticalOptions = LayoutOptions.Start,
						HorizontalOptions = LayoutOptions.FillAndExpand,
						Children = {_btnButton, _myLabel, _btnRemobeImage}
					}
				}
			};

			Content = new ScrollView
			{
				Content = _layout
			};

			_btnButton.Clicked += BtnButtonOnClicked;
			_btnRemobeImage.Clicked +=BtnRemobeImageOnClicked;
		}

		private void BtnRemobeImageOnClicked(object sender, EventArgs eventArgs)
		{
			var img = _layout.Children[_layout.Children.Count - 1] as Image;
			
			if (img == null) return;

			_layout.Children.Remove(img);
			_imgCount--;

			SetText();
		}

		private void SetText()
		{
			_myLabel.Text = "Image Count: " + _imgCount;
		}

		private void BtnButtonOnClicked(object sender, EventArgs eventArgs)
		{
			var imgUri = @"http://cdn.wall88.com/51b806946733147148.jpg";

			ImageUtils.DownloadImage(imgUri, AddImage);
		}

		private void AddImage(byte[] imgBytes)
		{
			Debug.WriteLine("Show image size = {0}", imgBytes.Length / 1024);

			var img = new Image
			{
				VerticalOptions = LayoutOptions.End,
				HeightRequest = 300,
				WidthRequest = 300,
				Source = ImageSource.FromStream(() => new MemoryStream(imgBytes))
			};

			_layout.Children.Add(img);
			_imgCount++;
			SetText();
		}
	}
}
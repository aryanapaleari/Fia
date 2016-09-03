using System;
using System.Collections.Generic;
using Acr.UserDialogs;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace AuladeSabado
{
	public partial class LoginPage : ContentPage
	{
		

		public LoginPage()
		{
			InitializeComponent();
		}

		async void Handle_Clicked(object sender, System.EventArgs e)
		{
			UserDialogs.Instance.ShowLoading("Logogando como " + txtlogin.Text);
			await Task.Delay(3000);

			UserDialogs.Instance.HideLoading();

			Navigation.InsertPageBefore(new NavigationPage(new tabpage()), this);
			await Navigation.PopAsync();


			
		}

		async void cdclick(object sender, System.EventArgs e)
		{
			UserDialogs.Instance.ShowLoading("Logogando como " + txtlogin.Text);
			await Task.Delay(3000);

			UserDialogs.Instance.HideLoading();

			Navigation.InsertPageBefore(new NavigationPage(new tabpage()), this);
			await Navigation.PopAsync();



		}
	}
}


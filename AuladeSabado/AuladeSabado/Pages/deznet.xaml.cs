using System;
using System.Collections.Generic;
using Acr.UserDialogs;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace AuladeSabado
{
	public partial class deznet : ContentPage
	{
		public deznet()
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

		async void Recuperar_Clicked(object sender, System.EventArgs e)
		{
			UserDialogs.Instance.ShowLoading("Recuperar senha de " + txtlogin.Text);
			await Task.Delay(3000);

			UserDialogs.Instance.HideLoading();

			Navigation.InsertPageBefore(new NavigationPage(new RecuperarSenha()), this);
			await Navigation.PopAsync();

		}
	}
}


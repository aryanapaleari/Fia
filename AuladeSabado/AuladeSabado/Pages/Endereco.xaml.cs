using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Net.Http;
using Acr.UserDialogs;

using Xamarin.Forms;

namespace AuladeSabado
{
	public partial class Endereco : ContentPage
	{
		public Endereco()
		{
			InitializeComponent();
		}

		async void Handle_TextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
		{
			string sURL = "https://viacep.com.br/ws/[0]/json/";
			HttpClient clinet = new HttpClient();

			var uri = new Uri(string.Format(sURL,txtCEP.Text));
			var response = await clinet.GetAsync(uri);

			if (response.IsSuccessStatusCode)
			{
				var content = await response.Content.ReadAsStreamAsync();

				UserDialogs.Instance.ShowSuccess("Requisição OK");
			}
			else 
			{
				UserDialogs.Instance.ShowError("");
			}

		}

		async void Unfocused_Focused(object sender, Xamarin.Forms.FocusEventArgs e)
		{
			string sURL = "http://viacep.com.br/ws/{0}/json/";

			HttpClient clinet = new HttpClient();

			var uri = new Uri(string.Format(sURL, txtCEP.Text));

			var response = await clinet.GetAsync(uri);

			CepResultModel cep = new CepResultModel();

			if (response.IsSuccessStatusCode)
			{
				var content = await response.Content.ReadAsStringAsync();
				cep = JsonConvert.DeserializeObject<CepResultModel>(content);

				txtEstado.Text = cep.uf;
				txtCidade.Text = cep.localidade;

				txtBairro.Text = cep.bairro;
				txtLogradouro.Text = cep.logradouro;
				txtNumero.Focus();

				UserDialogs.Instance.ShowSuccess("Requisição OK");
			}
			else
			{
				UserDialogs.Instance.ShowError("Erro ");
			}
		}
	}
}


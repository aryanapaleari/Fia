using System;
using System.Collections.Generic;
using System.Net.Http;
using Acr.UserDialogs;
using Newtonsoft.Json;
using Plugin.Geolocator;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace AuladeSabado
{
	public partial class dados : ContentPage
	{
		public dados()
		{
			InitializeComponent();
			geoloc();
		}
		async void geoloc()
		{
			
			var locator = CrossGeolocator.Current;
			locator.DesiredAccuracy = 50;

			var position = await locator.GetPositionAsync(10000);
			MapSpan.FromCenterAndRadius(new Position(position.Latitude, position.Longitude), Distance.FromMiles(1));
			var pin = new Pin
			{
				Type = PinType.Place, Position = new Position(position.Latitude, position.Longitude), Label = "Minha Localização", Address = "Terra do Nunca"

			};
			string url = "http://api.geonames.org/findNearByWeatherJSON?last=" + position.Latitude.ToString() + "&lng=" + position.Longitude.ToString() + "&username=deznetfiap";

			HttpClient clinet = new HttpClient();

			var uri = new Uri(url);

			var response = await clinet.GetAsync(uri);
		
			TempoResultModel tempo = new TempoResultModel();

			lblLat.Text = position.Latitude.ToString();
			lblLong.Text = position.Longitude.ToString();


			if (response.IsSuccessStatusCode)
			{
				var content = await response.Content.ReadAsStringAsync();

				tempo = JsonConvert.DeserializeObject<TempoResultModel>(content);
				UserDialogs.Instance.ShowSuccess("Requisição OK");

				lblLoc.Text = tempo.weatherObservation.stationName;
				lblTemp.Text = tempo.weatherObservation.temperature;


			}
			else
			{
				UserDialogs.Instance.ShowError("Erro ");
			}









		}
	}
}


using System;
namespace AuladeSabado
{
	public class TempoResultModel
	{
		

		public  WeatherObservation weatherObservation
		{ get; set;}

		public TempoResultModel()
		{
		}
	}
	public class WeatherObservation
	{
		public string temperature { get; set; }
		public string stationName { get; set; }
		//public string temperature { get; set;}
	}
}


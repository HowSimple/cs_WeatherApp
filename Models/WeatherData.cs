
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;

namespace WeatherApp.Models
{
	public partial class WeatherContainer 
	{


		public WeatherContainer(string zipcode)
		{
			APIcall(zipcode);
		}

		public static double CurrentTemp(string zipcode)
		{
			return CurrentTemp_APIcall(zipcode);

		}

		//public static WeatherContainer PopulateWeatherData(string zipcode , ref WeatherContainer)




		private static WeatherContainer APIcall(string zipcode)
		{

			try
			{
				string apikey = "eab00506d1f68b81e983df6b85c6e321";
				string uri = "http://api.openweathermap.org/data/2.5/weather?zip=" + zipcode + ",US&APPID=" + apikey + "&units=imperial";
				WebClient client = new WebClient( );
				string json = client.DownloadString(uri);
				//PopulateWeatherData(zipcode , )
				WeatherContainer response = JsonConvert.DeserializeObject<WeatherContainer>(json);

				return response;

			}
			catch ( System.Net.WebException )
			{
				;
			}
		}



	}


}
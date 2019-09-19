using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using Newtonsoft.Json;

namespace WeatherApp.Models
{
	public partial class WeatherApi
	{
			public ApiContainer Response;


			public WeatherApi(string zipcode)
			{
				//APIcall(zipcode);

				try
				{
					string apikey = "eab00506d1f68b81e983df6b85c6e321";
					string uri = "http://api.openweathermap.org/data/2.5/weather?zip=" + zipcode + ",US&APPID=" + apikey + "&units=imperial";
					WebClient client = new WebClient( );
					string json = client.DownloadString(uri);
					//PopulateWeatherData(zipcode , )
					Response = JsonConvert.DeserializeObject<ApiContainer>(json);

				}
				catch ( System.Net.WebException )
				{
					;
				}
			}

			

			//public static WeatherContainer PopulateWeatherData(string zipcode , ref WeatherContainer)


			public class ApiContainer
			{
				
				public Coord coord { get; set; }
				public List<Weather> weather { get; set; }
				public string @base { get; set; }
				public Main main { get; set; }
				public int visibility { get; set; }
				public Wind wind { get; set; }
				public Clouds clouds { get; set; }
				public int dt { get; set; }
				public Sys sys { get; set; }
				public int timezone { get; set; }
				public int id { get; set; }
				public string name { get; set; }
				public int cod { get; set; }

			}

			
			public class Coord
			{
				public double lon { get; set; }
				public double lat { get; set; }
			}
			public class Weather
			{
				public int id { get; set; }
				public string main { get; set; }
				public string description { get; set; }
				public string icon { get; set; }
			}
			public class Main
			{
				public double temp { get; set; }
				public double pressure { get; set; }
				public double humidity { get; set; }
				public double temp_min { get; set; }
				public double temp_max { get; set; }
			}
			public class Wind
			{
				public double speed { get; set; }
				public double deg { get; set; }
			}
			public class Clouds
			{
				public int all { get; set; }
			}
			public class Sys
			{
				public int type { get; set; }
				public int id { get; set; }
				public double message { get; set; }
				public string country { get; set; }
				public int sunrise { get; set; }
				public int sunset { get; set; }
			}


	}
	
}
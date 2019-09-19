using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Web;
using Newtonsoft.Json;
using WeatherApp.Properties;

namespace WeatherApp.Models
{
	public partial class WeatherApi
	{
			public ApiContainer Response;

			public WeatherApi(string zipcode)
			{
				try
				{
					string apikey = Resources.API_KEY;
					string uri = "http://api.openweathermap.org/data/2.5/weather?zip=" 
					             + zipcode + ",US&APPID=" + apikey + "&units=imperial";
					WebClient client = new WebClient( );
					string json = client.DownloadString(uri);
					Response = JsonConvert.DeserializeObject<ApiContainer>(json);

				}
				catch ( System.Net.WebException )
				{
					// TODO: add exception handling;
				}
			}
	}
}
using Newtonsoft.Json;
using System.Net;
using WeatherApp.Properties;
using System;

namespace WeatherApp.Models
{
	public partial class ApiClient
	{
		public ApiData data;

		public ApiClient(string zipcode)
		{
			try
			{
				string apikey = Resources.API_KEY;
				string uri = "http://api.openweathermap.org/data/2.5/weather?zip="
							 + zipcode + ",US&APPID=" + apikey + "&units=imperial";
				WebClient client = new WebClient( );
				string json = client.DownloadString(uri);
				data = JsonConvert.DeserializeObject<ApiData>(json);

			}
			catch (WebException excepetion)
			{
				if ( excepetion.Status == WebExceptionStatus.ProtocolError )
				{
					var response = excepetion.Response as HttpWebResponse;
					if ( response != null )
					{
						Console.WriteLine("HTTP Status Code: " + response.StatusCode);
					}
					throw;
				}
				
			}
		}
	}
}
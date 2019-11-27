using Newtonsoft.Json;
using System.Net;
using WeatherApp.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

namespace WeatherApp.Models
{
	public class ApiClient
	{
		public ApiData data;
		public string icon;

		public string getApiUri(string zipcode, string units = "imperial")
		{
			string apikey = Resources.API_KEY; // OpenWeatherMaps API Key
			string uri = "http://api.openweathermap.org/data/2.5/weather?zip="
					+ zipcode + ",US&APPID=" + apikey + "&units="+ units;
			return uri;
		}
		public string getIconUri()
		{
			string iconID = data.weather[0].icon;		
			string uri = "http://openweathermap.org/img/wn/"
				+iconID+"@2x.png";
			return uri;
			
		}
		public ApiClient(string zipcode)
		{
			try
			{
				string uri = getApiUri(zipcode); 
				WebClient client = new WebClient( );
				string json = client.DownloadString(uri);
				data = JsonConvert.DeserializeObject<ApiData>(json);
				icon = getIconUri();
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
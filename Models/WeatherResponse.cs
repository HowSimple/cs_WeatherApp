using System.Collections.Generic;

namespace WeatherApp.Models
{
	public static class Repository
	{
		private static List<WeatherResponse> responses = new List<WeatherResponse>( );

		public static IEnumerable<WeatherResponse> Responses
		{
			get { return responses; }
		}
		public static void AddResponse(WeatherResponse response)
		{
			responses.Add(response);
		}
	}


	public class WeatherResponse
	{
		//[Required(ErrorMessage = "Please enter your zipcode")]
		public string Zipcode { get; set; }

	}

}
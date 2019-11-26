using System.Collections.Generic;

namespace WeatherApp.Models
{
	public static class Repository
	{
		private static List<FormResponse> responses = new List<FormResponse>( );

		public static IEnumerable<FormResponse> Responses
		{
			get { return responses; }
		}
		public static void AddResponse(FormResponse response)
		{
			responses.Add(response);
		}
	}

	
	public class FormResponse
	{
		//[Required(ErrorMessage = "Please enter your zipcode")]
		public string Zipcode { get; set; }

		public ApiClient weatherData;


	}

}
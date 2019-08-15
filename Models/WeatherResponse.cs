using System.ComponentModel.DataAnnotations;

namespace WeatherApp.Models
{
	public class WeatherResponse
	{
		[Required(ErrorMessage = "Please enter your zipcode")]
		public string Zipcode { get; set; }

	}
}
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.IO;
using System.Web.Mvc;
using System.Net;
using System.Web.UI.WebControls;
using System;

namespace WeatherApp.Controllers
{
	public class UI
	{
		protected void Button_Click(Object sender, EventArgs e)
		{


		}
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
		public int pressure { get; set; }
		public int humidity { get; set; }
		public double temp_min { get; set; }
		public double temp_max { get; set; }
	}
	public class Wind
	{
		public double speed { get; set; }
		public int deg { get; set; }
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
	public class RootObject
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

	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View( );
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View( );
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View( );
		}


		private static readonly HttpClient Client = new HttpClient( );
		public static double CurrentTemp(string zipcode)
		{
			return  CurrentTemp_APIcall(zipcode);

		}

		public static double CurrentTemp_APIcall(string zipcode)
		{
			string apikey = "eab00506d1f68b81e983df6b85c6e321";
			string uri = "http://api.openweathermap.org/data/2.5/weather?zip=" + zipcode + ",US&APPID=" + apikey + "&units=imperial";
			//string json = await Client.GetStringAsync(uri);
			WebClient client = new WebClient( );
			string json = client.DownloadString(uri); 
			var response = JsonConvert.DeserializeObject<RootObject>(json);

			return response.main.temp;


		}
	}
}
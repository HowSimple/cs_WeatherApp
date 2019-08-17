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
using WeatherApp.Models;

namespace WeatherApp.Controllers
{
	public class HomeController : Controller
	{
		[HttpGet]
		public ActionResult Index()
		{
			ViewBag.Title = "";
			return View( );
		}
		[HttpPost]
		public ActionResult Index(WeatherResponse response)
		{
			ViewBag.Title = Request.Form["zipcode"];
			string zipcode = Request.Form["zipcode"];
			double temperature = CurrentTemp(zipcode);
			ViewBag.Temperature = temperature;

			return View( "Weather");
		}


		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View( );
		}

		public ActionResult Weather()
		{
			return View();
		}
		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";
			
			return View( );
		}
		
		private static readonly HttpClient Client = new HttpClient( );
		public static double CurrentTemp(string zipcode)
		{
			return CurrentTemp_APIcall(zipcode);

		}

		public static double CurrentTemp_APIcall(string zipcode)
		{
			try
			{

				string apikey = "eab00506d1f68b81e983df6b85c6e321";
				string uri = "http://api.openweathermap.org/data/2.5/weather?zip=" + zipcode + ",US&APPID=" + apikey + "&units=imperial";
				//string json = await Client.GetStringAsync(uri);
				WebClient client = new WebClient( );
				string json = client.DownloadString(uri);
				var response = JsonConvert.DeserializeObject<WeatherData.RootObject>(json);

				return response.main.temp;

			}
			catch ( System.Net.WebException )
			{
				return -9999.9999;
			}

		}
	}

}
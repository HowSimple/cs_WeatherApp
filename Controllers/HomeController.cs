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
			ViewBag.Title = "Weather Lookup";
			return View( );
		}
		[HttpPost]
		public ActionResult Index(WeatherResponse response)
		{
			ViewBag.Title = "Weather Lookup";
			string zipcode = Request.Form["zipcode"];
			WeatherApi call = new WeatherApi(zipcode);

				
			



			return View( "Weather", call);
		}

		

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View( );
		}

		
		
		
		//private static readonly HttpClient Client = new HttpClient( );
		
	}

}
using System.Web.Mvc;
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
		public ActionResult Index(FormResponse response)
		{
			ViewBag.Title = "Weather Lookup";
			string zipcode = Request.Form["zipcode"];
			ApiClient call = new ApiClient(zipcode);

			return View("Weather" , call);
		}
		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";
			return View( );
		}
	}
}
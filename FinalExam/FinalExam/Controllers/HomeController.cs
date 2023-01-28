using FinalExam.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FinalExam.Controllers
{
    public class HomeController : Controller
    {
		private readonly MaximContext _maximContext;

		public HomeController(MaximContext maximContext)
        {
			_maximContext = maximContext;
		}

        public IActionResult Index()
        {


            return View(_maximContext.servicesSections.ToList());
        }

        
    }
}
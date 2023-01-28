using FinalExam.Helper;
using FinalExam.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalExam.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class ServicesSectionController : Controller
    {
        private readonly MaximContext _maximContext;
        private readonly IWebHostEnvironment _env;

        public ServicesSectionController(MaximContext maximContext, IWebHostEnvironment env)
        {
            _maximContext = maximContext;
            _env = env;
        }
        public IActionResult Index()
        {
            List<ServicesSection> services = _maximContext.servicesSections.ToList();
            return View(services);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ServicesSection services)
        {
            if (!ModelState.IsValid) return View();

            if (services.ImageFile.ContentType != "image/png" && services.ImageFile.ContentType != "image/jpeg")
            {
                ModelState.AddModelError("ImageFile", "only png");
                return View();
            }
            if (services.ImageFile.Length > 3142357)
            {
                ModelState.AddModelError("ImageFile", "max 3 mb");
                return View();
            }

            services.Image = FileManager.SaveFile(_env.WebRootPath, "uploads/servicesSection", services.ImageFile);

            _maximContext.servicesSections.Add(services);
            _maximContext.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Update(int id)
        {
            ServicesSection services = _maximContext.servicesSections.Find(id);
            return View(services);
        }
        [HttpPost]
        public IActionResult Update(ServicesSection services)
        {
            ServicesSection exitsServices = _maximContext.servicesSections.FirstOrDefault(x => x.Id == services.Id);
            if (!ModelState.IsValid) return View();
            if (exitsServices == null) return NotFound();
            if (services.ImageFile != null)
            {
                if (services.ImageFile.ContentType != "image/png" && services.ImageFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("ImageFile", "only png");
                    return View();
                }
                if (services.ImageFile.Length > 3145728)
                {
                    ModelState.AddModelError("ImageFile", "max 3 mb");
                    return View();
                }
                FileManager.DeleteFile(_env.WebRootPath, "uploads/servicesSection", exitsServices.Image);
                exitsServices.Image = FileManager.SaveFile(_env.WebRootPath, "uploads/teams", services.ImageFile);
            }

            exitsServices.Name = services.Name;
            
            exitsServices.Description = services.Description;

            _maximContext.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Delete(int id)
        {
            ServicesSection services = _maximContext.servicesSections.FirstOrDefault(x => x.Id == id);
            if (services == null) return NotFound();
            if (services.Image != null)
            {
                FileManager.DeleteFile(_env.WebRootPath, "uploads/servicesSection", services.Image);
            }
            _maximContext.servicesSections.Remove(services);
            _maximContext.SaveChanges();
            return RedirectToAction("index");
        }
    }
}

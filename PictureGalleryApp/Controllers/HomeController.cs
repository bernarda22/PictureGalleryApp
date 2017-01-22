using Microsoft.AspNetCore.Mvc;
using PictureGalleryModel;

namespace PictureGalleryApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPictureRepository _pictureRepository;

        public HomeController(IPictureRepository pictureGallery)
        {
            _pictureRepository = pictureGallery;
        }

        public IActionResult Index()
        {
            var pictures = _pictureRepository.GetAllSelectedForHeadline();
            return View(pictures);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}

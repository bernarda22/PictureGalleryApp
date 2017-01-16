using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using PictureGalleryApp.Models;
using PictureGalleryApp.Models.AlbumViewModels;
using PictureGalleryModel;
using System.IO;
using System.Threading.Tasks;

namespace PictureGalleryApp.Controllers
{
    [Authorize]
    public class AlbumController : Controller
    {
        private readonly IHostingEnvironment _hostingEnv;
        private readonly IUserRepository _userRepository;
        private readonly IAlbumRepository _repository;
        private readonly UserManager<ApplicationUser> _userManager;

        public AlbumController(IAlbumRepository repository, UserManager<ApplicationUser> userManager, IUserRepository userRepository, IHostingEnvironment env)
        {
            _repository = repository;
            _userManager = userManager;
            _userRepository = userRepository;
            _hostingEnv = env;
        }

        public async Task<IActionResult> Index()
        {
            ApplicationUser currentUser = await _userManager.GetUserAsync(HttpContext.User);
            User user = _userRepository.Get(currentUser.Email);
            var albums = _repository.GetAll(user);
            return View(albums);
        }
        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(AlbumViewModel album)
        {
            string filename = null;
            if (album.Thumbnail != null)
            { 
                filename = ContentDispositionHeaderValue
                        .Parse(album.Thumbnail.ContentDisposition)
                        .FileName
                        .Trim('"');
                filename = _hostingEnv.WebRootPath + $@"\{filename}";

                using (FileStream fs = System.IO.File.Create(filename))
                {
                    album.Thumbnail.CopyTo(fs);
                    fs.Flush();
                }
            }

            return View();
        }


        public ActionResult Image(string id)
        {
            var dir = Microsoft.AspNetCore.Server.MapPath("/Images");
            var path = Path.Combine(dir, id + ".jpg"); //validate the path for security or use other means to generate the path.
            return base.File(path, "image/jpeg");
        }

    }
}

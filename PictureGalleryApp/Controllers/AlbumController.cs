using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PictureGalleryApp.Models;
using PictureGalleryApp.Models.AlbumViewModels;
using PictureGalleryModel;
using System;
using System.IO;
using System.Threading.Tasks;

namespace PictureGalleryApp.Controllers
{
    [Authorize]
    public class AlbumController : Controller
    {
        private readonly IHostingEnvironment _hostingEnv;
        private readonly IUserRepository _userRepository;
        private readonly IAlbumRepository _albumRepository;
        private readonly IPictureRepository _pictureRepository;

        private readonly UserManager<ApplicationUser> _userManager;

        public AlbumController(IAlbumRepository repository, IPictureRepository pictureRepository, UserManager<ApplicationUser> userManager, IUserRepository userRepository, IHostingEnvironment env)
        {
            _albumRepository = repository;
            _userManager = userManager;
            _userRepository = userRepository;
            _pictureRepository = pictureRepository;
            _hostingEnv = env;
        }

        public async Task<IActionResult> Index()
        {
            User user = await getCurrentUser();
            var albums = _albumRepository.GetAll(user);
            return View(albums);
        }
        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AlbumViewModel model)
        {
            User user = await getCurrentUser();
            var album = new Album();
            album.Title = model.Title;
            album.CreatedByUser = user;
            album.Id = Guid.NewGuid();
            album.DateCreated = DateTime.Now;

            foreach(var image in model.GalleryImages)
            {
                string filename = _hostingEnv.WebRootPath + $@"\{Guid.NewGuid()}";
                using (FileStream fs = System.IO.File.Create(filename))
                {
                    image.CopyTo(fs);
                    fs.Flush();
                }
                Picture picture = new Picture();
                picture.Album = album;
                picture.PathToData = filename;
                _pictureRepository.Add(picture);
                album.Pictures.Add(picture);
            }
            user.AlbumsCreated.Add(album);
           
            return RedirectToAction(nameof(AlbumController.Index), "Album");
        }

        private async Task<User> getCurrentUser()
        {
            ApplicationUser currentUser = await _userManager.GetUserAsync(HttpContext.User);
            return _userRepository.Get(currentUser.Email);
        }

        //public iactionresult image(string id)
        //{
        //    var dir = microsoft.aspnetcore.server.mappath("/images");
        //    var path = path.combine(dir, id + ".jpg"); //validate the path for security or use other means to generate the path.
        //    return base.file(path, "image/jpeg");
        //}

    }
}

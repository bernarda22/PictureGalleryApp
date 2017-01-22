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

        //Album/Create
        [HttpPost]
        public async Task<IActionResult> Create(AlbumViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await getCurrentUser();
                var album = new Album();
                album.Title = model.Title;
                album.CreatedByUser = user;
                album.Id = Guid.NewGuid();
                album.DateCreated = DateTime.Now;

                foreach (var image in model.GalleryImages)
                {
                    string filename = _hostingEnv.WebRootPath + $@"\gallery-images\{Guid.NewGuid()}";
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

            return View(model);
        }

        public IActionResult Details(string id)
        {
            var album = _albumRepository.Get(new Guid(id));
            return View(album);
        }

        private async Task<User> getCurrentUser()
        {
            ApplicationUser currentUser = await _userManager.GetUserAsync(HttpContext.User);
            return _userRepository.Get(currentUser.Email);
        }

        public async Task<IActionResult> Image(string id)
        {
            User user = await getCurrentUser();
            var picture = _pictureRepository.Get(new Guid(id));
            return PhysicalFile(picture.PathToData, "image/jpeg");
        }

    }
}

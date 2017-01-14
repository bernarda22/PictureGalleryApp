using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PictureGalleryApp.Models;
using PictureGalleryModel;
using System.Threading.Tasks;

namespace PictureGalleryApp.Controllers
{
    [Authorize]
    public class AlbumController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IAlbumRepository _repository;
        private readonly UserManager<ApplicationUser> _userManager;
        public AlbumController(IAlbumRepository repository, UserManager<ApplicationUser> userManager, IUserRepository userRepository)
        {
            _repository = repository;
            _userManager = userManager;
            _userRepository = userRepository;
        }

        public async Task<IActionResult> Index()
        {
            // Get currently logged -in user using userManager
            ApplicationUser currentUser = await _userManager.GetUserAsync(HttpContext.User);
            User user = _userRepository.Get(currentUser.Email);
            var albums = _repository.GetAll(user);
            return View(albums);
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PictureGalleryApp.Models;
using PictureGalleryApp.Models.AlbumViewModels;
using PictureGalleryModel;
using System;
using System.Threading.Tasks;

namespace PictureGalleryApp.Controllers
{
    [Authorize]
    public class CommentController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IAlbumRepository _albumRepository;
        private readonly IPictureRepository _pictureRepository;
        private readonly ICommentRepository _commentRepository;

        private readonly UserManager<ApplicationUser> _userManager;

        public CommentController(IAlbumRepository repository, IPictureRepository pictureRepository, UserManager<ApplicationUser> userManager, IUserRepository userRepository, ICommentRepository commentRepository)
        {
            _albumRepository = repository;
            _userManager = userManager;
            _userRepository = userRepository;
            _pictureRepository = pictureRepository;
            _commentRepository = commentRepository;
        }

        private async Task<User> getCurrentUser()
        {
            ApplicationUser currentUser = await _userManager.GetUserAsync(HttpContext.User);
            return _userRepository.Get(currentUser.Email);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AlbumViewModel model)
        {
            var user = await getCurrentUser();
            var commentData = model.CreatedComment;
            
            var picture = _pictureRepository.Get(new Guid(commentData.PictureId));
            var comment = new Comment();
            comment.Text = commentData.Text;
            comment.CreatedBy = user;
            comment.Commented = picture;
            picture.Comments.Add(comment);

            _commentRepository.Add(comment);

            return RedirectToAction(nameof(AlbumController.Details), "Album", new { id = model.SelectedAlbum.Id.ToString() });
        }

        [HttpGet]
        public IActionResult Index(string pictureId)
        {
            var comments = _commentRepository.GetAll(new Guid(pictureId));
            return this.PartialView("_Comments", comments);
        }
    }
}
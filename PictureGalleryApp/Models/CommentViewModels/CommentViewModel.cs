using System.ComponentModel.DataAnnotations;

namespace PictureGalleryApp.Models.AlbumViewModels
{
    public class CommentViewModel
    {
        [Required]
        public string PictureId { get; set; }

        [Required]
        public string Text { get; set; }
    }
}

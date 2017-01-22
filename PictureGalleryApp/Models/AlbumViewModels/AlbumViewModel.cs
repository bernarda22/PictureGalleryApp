using Microsoft.AspNetCore.Http;
using PictureGalleryModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PictureGalleryApp.Models.AlbumViewModels
{
    public class AlbumViewModel
    {
        [Required]
        [Display(Name = "Album title")]
        public string Title { get; set; }

        [Display(Name = "Upload images")]
        public List<IFormFile> GalleryImages { get; set; }

        public Album SelectedAlbum { get; set; }

        public CommentViewModel CreatedComment { get; set; }
    }
}

using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PictureGalleryApp.Models.AlbumViewModels
{
    public class AlbumViewModel
    {
        [Required]
        [Display(Name = "Album title")]
        public string Title { get; set; }

        [Display(Name = "Images")]
        public List<IFormFile> GalleryImages { get; set; }
    }
}

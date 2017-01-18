using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureGalleryModel
{
    public class User
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Admin { get; set; }
        public virtual List<Picture> LikedPictures { get; set; }
        public virtual List<Album> AlbumsCreated { get; set; }
        public virtual List<Comment> Comments { get; set; }

        public User()
        {
            LikedPictures = new List<Picture>();
            AlbumsCreated = new List<Album>();
            Comments = new List<Comment>();
            Admin = false;
        }
    }
}

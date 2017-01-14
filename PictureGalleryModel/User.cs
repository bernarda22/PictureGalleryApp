using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureGalleryModel
{
    public class User
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Admin { get; set; }
        public List<User> TrackingUsers { get; set; }
        public List<Picture> LikedPictures { get; set; }
        public List<Album> AlbumsCreated { get; set; }
        public List<Comment> Comments { get; set; }

        public User(string email, string firstName, string lastName)
        {
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            Admin = false;
        } 

        public User()
        {

        }
    }
}

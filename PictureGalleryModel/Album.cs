using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureGalleryModel
{
    public class Album
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime DateCreated { get; set; }
        public User CreatedByUser { get; set; }                  // mogu li imati klasu user, hoce liste biti prazne na pocetku, byte za prijenos slike?
        public List<Picture> Pictures { get; set; }

        public Album(string title, User user)
        {
            Id = Guid.NewGuid();
            Title = title;
            DateCreated = DateTime.Now;
            CreatedByUser = user;
        }

        public Album()
        {
        }
    }
}

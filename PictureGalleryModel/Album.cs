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
        public User CreatedByUser { get; set; }              
        public virtual List<Picture> Pictures { get; set; }

        public Album()
        {
            Id = Guid.NewGuid();
            DateCreated = DateTime.Now;
            Pictures = new List<Picture>();
        }
    }
}

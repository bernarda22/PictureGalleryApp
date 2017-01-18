using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureGalleryModel
{
    public class Comment
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public DateTime DateCreated { get; set; }
        public virtual Picture Commented { get; set; }
        public virtual User CreatedBy { get; set; }

        /*public Comment(string text, Picture commented, User createdby)
        {
            Id = Guid.NewGuid();
            Text = text;
            Commented = commented;
            CreatedBy = createdby;
            DateCreated = DateTime.Now;
        }*/

        public Comment()
        {
            Id = Guid.NewGuid();
            DateCreated = DateTime.Now;
        }
    }
}

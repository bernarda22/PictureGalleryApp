using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureGalleryModel
{
    public interface ICommentRepository
    {
        List<Comment> GetAll(Guid pictureId);
        Comment Get(Guid commentId);
        void Add(Comment comment);
    }
}

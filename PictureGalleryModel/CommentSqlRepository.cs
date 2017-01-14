using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureGalleryModel
{
    public class CommentSqlRepository : ICommentRepository
    {
        public readonly GalleryDbContext _context;

        public CommentSqlRepository(GalleryDbContext context)
        {
            _context = context;
        }

        public void Add(Comment comment)
        {
            if (Get(comment.Id) != null)
            {
                throw new DuplicateCommentException(String.Format("duplicate id: {0}", comment.Id));
            }
            _context.Comments.Add(comment);
            _context.SaveChanges();
        }

        public Comment Get(Guid commentId)
        {
            return _context.Comments.Where(s => s.Id == commentId).FirstOrDefault();
        }

        public List<Comment> GetAll(Guid pictureId)
        {
            return _context.Comments.Where(s => s.Commented.Id == pictureId).ToList();
        }
    }
}

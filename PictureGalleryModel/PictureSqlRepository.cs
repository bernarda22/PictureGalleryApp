using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureGalleryModel
{
    public class PictureSqlRepository : IPictureRepository
    {
        public readonly GalleryDbContext _context;

        public PictureSqlRepository(GalleryDbContext context)
        {
            _context = context;
        }

        public List<Picture> GetAllSelectedForHeadline()
        {
            return _context.Pictures.ToList();
        }

        public void Add(Picture picture)
        {
            if (Get(picture.Id) != null)
            {
                throw new DuplicatePictureException(String.Format("duplicate id: {0}", picture.Id));
            }
            _context.Pictures.Add(picture);
            _context.SaveChanges();
        }

        public Picture Get(Guid pictureId)
        {
            return _context.Pictures.Where(s => s.Id == pictureId).FirstOrDefault();
        }

        public bool Remove(Guid pictureId, User user)
        {
            var picture = Get(pictureId);
            if (picture == null || picture.Album.CreatedByUser != user)
            {
                return false;
            }
            _context.Pictures.Remove(picture);
            _context.SaveChanges();
            return true;
        }

        public void Update(Picture picture, User user)
        {
            if (picture.Album.CreatedByUser != user)
            {
                throw new PictureAccessDeniedException("Acess denied");
            }
            _context.Entry(picture).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}

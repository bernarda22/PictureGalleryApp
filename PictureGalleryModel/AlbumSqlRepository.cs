using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureGalleryModel
{
    public class AlbumSqlRepository : IAlbumRepository
    {
        public readonly GalleryDbContext _context;

        public AlbumSqlRepository(GalleryDbContext context)
        {
            _context = context;
        }

        public void Add(Album album)
        {
            if (Get(album.Id, album.CreatedByUser) != null)
            {
                throw new DuplicateAlbumException(String.Format("duplicate id: {0}", album.Id));
            }
            _context.Albums.Add(album);
            _context.SaveChanges();
        }

        public Album Get(Guid albumId, User user)
        {
            var album = _context.Albums.Where(s => s.Id == albumId).FirstOrDefault();
            if (album != null && album.CreatedByUser != user)
            {
                throw new AlbumAccessDeniedException("album is not available for this user");
            }
            return album;
        }

        public List<Album> GetAll(User user)
        {
            return _context.Albums.Where(s => s.CreatedByUser == user).OrderByDescending(s => s.DateCreated).ToList();
        }

        public bool Remove(Guid albumId, User user)
        {
            var album = Get(albumId, user);
            if (album == null)
            {
                return false;
            }
            _context.Albums.Remove(album);
            _context.SaveChanges();
            return true;
        }

        public void Update(Album album, User user)
        {
            if (album.CreatedByUser != user)
            {
                throw new AlbumAccessDeniedException("Acess denied");
            }
            // Setting state of the TodoItem as "modified" marks object as "dirty" inside our context.
            // Because of that, when we call SaveChanges(), EF will have to update all properties of todoItem object inside DB 
            // What row it will actually update depends on the key {todoItem.Id}
            _context.Entry(album).State = EntityState.Modified;
            _context.SaveChanges();
        }

    }
}

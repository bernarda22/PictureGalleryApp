using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureGalleryModel
{
    public class UserSqlRepository : IUserRepository
    {
        public readonly GalleryDbContext _context;

        public UserSqlRepository(GalleryDbContext context)
        {
            _context = context;
        }

        public void Add(User user)
        {
            if (Get(user.Email) != null)
            {
                throw new DuplicateUserException(String.Format("duplicate email: {0}", user.Email));
            }
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public User Get(string email)
        {
           return _context.Users.Where(s => s.Email == email).FirstOrDefault();
        }

    }
}

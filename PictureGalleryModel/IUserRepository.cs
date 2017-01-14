using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureGalleryModel
{
    public interface IUserRepository
    {
        User Get(string email);
        void Add(User user);
    }
}

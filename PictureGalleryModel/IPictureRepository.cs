using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureGalleryModel
{
    public interface IPictureRepository
    {
        List<Picture> GetAllSelectedForHeadline();
        Picture Get(Guid pictureId);
        void Add(Picture picture);
        bool Remove(Guid pictureId, User user);
        void Update(Picture picture, User user);
    }
}

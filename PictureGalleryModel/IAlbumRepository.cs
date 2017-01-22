using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureGalleryModel
{
    public interface IAlbumRepository
    {
        /// <summary >
        /// Gets Album for a given id. Throw AlbumAccessDeniedException
        /// with appropriate message if user is not the owner of the Album
        /// </ summary >
        /// <param name =" albumId "> Album Id </ param >
        /// <param name =" userId ">Id of the user that is trying to fetch the data</ param >
        /// <returns > Album if found , null otherwise </ returns >
        Album Get(Guid albumId);
        /// <summary >
        /// Adds new Album object in database .
        /// If object with the same id already exists ,
        /// method should throw DuplicateAlbumException with the message
        ///  " duplicate id: {id }".
        /// </ summary >
        void Add(Album album);
        /// <summary >
        /// Tries to remove Album with given id from the database . Throw
        /// AlbumAccessDeniedException with appropriate message if user is not the owner of the Album
        /// </ summary >
        /// <param name =" albumId "> Album Id </ param >
        /// <param name =" userId ">Id of the user that is trying to remove the data</ param >
        /// <returns > True if success , false otherwise </ returns >
        bool Remove(Guid albumId);
        /// <summary >
        /// Updates given Album in database .
        /// If Album does not exist , method will add one . Throw
        /// AlbumAccessDeniedException with appropriate message if user is not
        /// the owner of the Album
        /// </ summary >
        /// <param name =" album "> Album </ param >
        /// <param name =" userId ">Id of the user that is trying to update the data</ param>
        void Update(Album album, User user);
        List<Album> GetAll(User user);
    }
}

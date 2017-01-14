using System;
using System.Runtime.Serialization;

namespace PictureGalleryModel
{
    [Serializable]
    internal class AlbumAccessDeniedException : Exception
    {
        private Guid albumId;
        private User userId;

        public AlbumAccessDeniedException()
        {
        }

        public AlbumAccessDeniedException(string message) : base(message)
        {
        }

        public AlbumAccessDeniedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public AlbumAccessDeniedException(User userId, Guid albumId)
        {
            this.userId = userId;
            this.albumId = albumId;
        }

        protected AlbumAccessDeniedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
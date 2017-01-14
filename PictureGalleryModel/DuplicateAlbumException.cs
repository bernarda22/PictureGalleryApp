using System;
using System.Runtime.Serialization;

namespace PictureGalleryModel
{
    [Serializable]
    internal class DuplicateAlbumException : Exception
    {
        public DuplicateAlbumException()
        {
        }

        public DuplicateAlbumException(string message) : base(message)
        {
        }

        public DuplicateAlbumException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DuplicateAlbumException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
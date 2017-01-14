using System;
using System.Runtime.Serialization;

namespace PictureGalleryModel
{
    [Serializable]
    internal class PictureAccessDeniedException : Exception
    {
        public PictureAccessDeniedException()
        {
        }

        public PictureAccessDeniedException(string message) : base(message)
        {
        }

        public PictureAccessDeniedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PictureAccessDeniedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
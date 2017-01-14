using System;
using System.Runtime.Serialization;

namespace PictureGalleryModel
{
    [Serializable]
    internal class DuplicatePictureException : Exception
    {
        public DuplicatePictureException()
        {
        }

        public DuplicatePictureException(string message) : base(message)
        {
        }

        public DuplicatePictureException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DuplicatePictureException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
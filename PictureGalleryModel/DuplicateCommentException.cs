using System;
using System.Runtime.Serialization;

namespace PictureGalleryModel
{
    [Serializable]
    internal class DuplicateCommentException : Exception
    {
        public DuplicateCommentException()
        {
        }

        public DuplicateCommentException(string message) : base(message)
        {
        }

        public DuplicateCommentException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DuplicateCommentException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
using System;
using System.Collections.Generic;

namespace PictureGalleryModel
{
    public class Picture
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PathToData { get; set; }           
        public DateTime DateCreated { get; set; }
        public Album Album { get; set; }
        public bool SelectedForHeadline { get; set; }
        public List<User> LikedByUsers { get; set; }
        public List<Comment> PictureCommented { get; set; } 

        public Picture(string name, Album album, string pathToData)
        {
            Id = Guid.NewGuid();
            Name = name;
            PathToData = pathToData;
            DateCreated = DateTime.Now;
            Album = album;
            SelectedForHeadline = false;
        }

        public Picture()
        {
        }
    }
}

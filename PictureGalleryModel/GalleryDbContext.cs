using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureGalleryModel
{
    public class GalleryDbContext : DbContext
    {
        public IDbSet<Album> Albums { get; set; }
        public IDbSet<Picture> Pictures { get; set; }
        public IDbSet<User> Users { get; set; }
        public IDbSet<Comment> Comments { get; set; }

        public GalleryDbContext(string connectionString) : base(connectionString)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Album>().HasKey(c => c.Id);
            modelBuilder.Entity<Album>().Property(c => c.Title).IsRequired();
            modelBuilder.Entity<Album>().Property(c => c.DateCreated).IsRequired();
            modelBuilder.Entity<Album>().HasRequired(a => a.CreatedByUser).WithMany(a => a.AlbumsCreated);

            modelBuilder.Entity<User>().HasKey(a => a.Email);
            modelBuilder.Entity<User>().Property(c => c.FirstName).IsRequired();
            modelBuilder.Entity<User>().Property(c => c.LastName).IsRequired();
            modelBuilder.Entity<User>().Property(c => c.Admin).IsRequired();
            modelBuilder.Entity<User>().HasMany(a => a.LikedPictures).WithMany(a => a.LikedByUsers);
            modelBuilder.Entity<User>().HasMany(a => a.LikedPictures).WithMany();
            modelBuilder.Entity<User>().HasOptional(a => a.TrackingUsers).WithMany();  // ?

            modelBuilder.Entity<Picture>().HasKey(a => a.Id);
            modelBuilder.Entity<Picture>().Property(c => c.Name).IsRequired();
            modelBuilder.Entity<Picture>().Property(c => c.PathToData).IsRequired();
            modelBuilder.Entity<Picture>().Property(c => c.DateCreated).IsRequired();
            modelBuilder.Entity<Picture>().Property(c => c.SelectedForHeadline).IsRequired();
            modelBuilder.Entity<Picture>().HasRequired(a => a.Album).WithMany(a => a.Pictures);

            modelBuilder.Entity<Comment>().HasKey(a => a.Id);
            modelBuilder.Entity<Comment>().Property(c => c.Text).IsRequired();
            modelBuilder.Entity<Comment>().Property(c => c.DateCreated).IsRequired();
            modelBuilder.Entity<Comment>().HasRequired(a => a.Commented).WithMany(a => a.PictureCommented);
            modelBuilder.Entity<Comment>().HasRequired(a => a.CreatedBy).WithMany(a => a.Comments);
        }
    }
}

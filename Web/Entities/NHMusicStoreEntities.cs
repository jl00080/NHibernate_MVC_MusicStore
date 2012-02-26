using System.Data.Entity;

namespace MvcMusicStore.Models
{
    public class NHMusicStoreEntities : DbContext
    {
        public DbSet<NHAlbum> Albums { get; set; }
        public DbSet<NHGenre> Genres { get; set; }
        public DbSet<NHArtist> Artists { get; set; }
        public DbSet<NHCart> Carts { get; set; }
        public DbSet<NHOrder> Orders { get; set; }
        public DbSet<NHOrderDetail> OrderDetails { get; set; }
    }
}
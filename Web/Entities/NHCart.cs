
namespace MvcMusicStore.Entities
{
    public class NHCart : Entity
    {
        //public virtual int RecordId { get; private set; }
        public virtual string CartId { get; set; }
        public virtual int AlbumId { get; set; }
        public virtual int Count { get; set; }
        public virtual System.DateTime DateCreated { get; set; }

        public virtual NHAlbum Album { get; set; }
    }
}
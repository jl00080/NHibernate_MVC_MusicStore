using System.Collections.Generic;
namespace MvcMusicStore.Entities
{
    public class NHArtist : Entity
    {
        //public virtual int ArtistId { get; private set; }
        public virtual string Name { get; set; }

        public virtual IList<NHAlbum> Albums { get; set; }

        public NHArtist()
        {
            Albums = new List<NHAlbum>();
        }
    }
}
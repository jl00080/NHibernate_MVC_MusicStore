using System.Collections.Generic;

namespace MvcMusicStore.Entities
{
    public partial class NHGenre : Entity
    {
        //public virtual int GenreId { get; private set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual IList<NHAlbum> Albums { get; set; }

        public NHGenre()
        {
            Albums = new List<NHAlbum>();
        } 
    }
}

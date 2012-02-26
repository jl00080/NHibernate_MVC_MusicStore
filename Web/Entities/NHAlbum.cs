using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Collections.Generic;

namespace MvcMusicStore.Entities
{
    public class NHAlbum : Entity
    {
        //public virtual int AlbumId { get; private set; }

        public virtual int GenreId { get; set; }

        public virtual int ArtistId { get; set; }

        public virtual string Title { get; set; }

        public virtual decimal Price { get; set; }

        public virtual string AlbumArtUrl { get; set; }

        public virtual NHGenre Genre { get; set; }
        public virtual NHArtist Artist { get; set; }
        public virtual IList<NHOrderDetail> OrderDetails { get; set; }

        public NHAlbum()
        {
            OrderDetails = new List<NHOrderDetail>();
        }

    }
}
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Collections.Generic;
using FluentNHibernate.Mapping;
using MvcMusicStore.Entities;

namespace MvcMusicStore.Mappings
{
    public class AlbumMap : ClassMap<NHAlbum>
    {
        public AlbumMap()
        {
            Table("Albums");
            OptimisticLock.Dirty();
            DynamicUpdate();
            Id(x => x.Id, "AlbumId");
            Map(x => x.Title);
            Map(x => x.Price);
            Map(x => x.AlbumArtUrl);
            References(x => x.Genre,"GenreId");
            References(x => x.Artist, "ArtistId");
            HasMany<NHOrderDetail>(x => x.OrderDetails).KeyColumn("AlbumId");
        }
    }
}
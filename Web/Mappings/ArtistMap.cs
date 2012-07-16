using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Collections.Generic;
using FluentNHibernate.Mapping;
using MvcMusicStore.Entities;

namespace MvcMusicStore.Mappings
{
    public class ArtistMap : ClassMap<NHArtist>
    {
        public ArtistMap()
        {
            Table("Artists");
            OptimisticLock.Dirty();
            DynamicUpdate();
            Id(x => x.Id).Column("ArtistId");
            Map(x => x.Name);
            HasMany(x => x.Albums).Inverse().Cascade.All();
        }
    }
}
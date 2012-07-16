using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Collections.Generic;
using FluentNHibernate.Mapping;
using MvcMusicStore.Entities;

namespace MvcMusicStore.Mappings
{
    public class GenreMap : ClassMap<NHGenre>
    {
        public GenreMap()
        {
            Table("Genres");
            OptimisticLock.Dirty();
            DynamicUpdate();
            Id(x => x.Id).Column("GenreId");
            Map(x => x.Name);
            Map(x => x.Description);
            HasMany(x => x.Albums).KeyColumn("GenreId").Inverse().Cascade.All();
        }
    }
}
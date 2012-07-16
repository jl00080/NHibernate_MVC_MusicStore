using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;
using MvcMusicStore.Entities;

namespace MvcMusicStore.Mappings
{
    public class CartMap : ClassMap<NHCart>
    {
        public CartMap()
        {
            Table("Carts");
            OptimisticLock.Dirty();
            DynamicUpdate();
            Id(x => x.Id,"RecordId");
            Map(x => x.CartId);
            Map(x => x.Count);
            Map(x => x.DateCreated);
            Map(x => x.AlbumId);
            References(x => x.Album,"AlbumId").Not.Insert().Not.Update();
        }
    }
}
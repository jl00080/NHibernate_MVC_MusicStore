using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;
using MvcMusicStore.Entities;

namespace MvcMusicStore.Mappings
{
    public class OrderDetialMap:ClassMap<NHOrderDetail>
    {
        public OrderDetialMap()
        {
            Table("OrderDetails");
            Id(x => x.Id,"OrderDetailId");
            Map(x => x.Quantity);
            Map(x => x.UnitPrice);
            Map(x => x.AlbumId);
            Map(x => x.OrderId);
            References(x => x.Album,"AlbumId").Not.Insert().Not.Update();
            References(x => x.Order,"OrderId").Not.Insert().Not.Update();
         }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;
using MvcMusicStore.Entities;

namespace MvcMusicStore.Mappings
{
    public class OrderMap : ClassMap<NHOrder>
    {
        public OrderMap()
        {
            Table("Orders");
            Id(x => x.Id, "OrderId");
            Map(x => x.OrderDate);
            Map(x => x.Username);
            Map(x => x.FirstName);
            Map(x => x.LastName);
            Map(x => x.Address);
            Map(x => x.City);
            Map(x => x.State);
            Map(x => x.PostalCode);
            Map(x => x.Country);
            Map(x => x.Phone);
            Map(x => x.Email);
            Map(x => x.Total);
            HasMany(x => x.OrderDetails).Inverse().Cascade.All();
        }
    }
}
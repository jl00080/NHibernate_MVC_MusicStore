using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Context;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using MvcMusicStore.Mappings;



namespace MvcMusicStore
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            //System.Data.Entity.Database.SetInitializer(new MvcMusicStore.Models.SampleData());


            log4net.Config.XmlConfigurator.Configure();

            var nhConfig = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008
                .ConnectionString(connstr => connstr.FromConnectionStringWithKey("mvcConnStr"))
                )
                .Mappings(mappings => mappings.FluentMappings
                .AddFromAssemblyOf<OrderMap>()
                )
                .ExposeConfiguration(c => c.SetProperty("current_session_context_class", "web"))
                .BuildConfiguration();
            SessionFactory = nhConfig.BuildSessionFactory();



            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            var session = SessionFactory.OpenSession();
            CurrentSessionContext.Bind(session);
        }

        protected void Application_EndRequest(object sender, EventArgs e)
        {
            var session = CurrentSessionContext.Unbind(SessionFactory);
            session.Dispose();
        }

        public static ISessionFactory SessionFactory
        {
            get;
            private set;
        }
    }
}
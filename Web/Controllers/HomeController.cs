using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MvcMusicStore.Models;
using MvcMusicStore.Entities;
using NHibernate.Linq;
using NHibernate;

namespace MvcMusicStore.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        ISession _session;

        public ActionResult Index()
        {
            // Get most popular albums
            var albums = NHGetTopSellingAlbums(5);

            return View(albums);
        }

        private IList<NHAlbum> NHGetTopSellingAlbums(int count)
        {
            _session = MvcApplication.SessionFactory.GetCurrentSession();

            var _query = from a in _session.Query<NHAlbum>()
                         orderby a.OrderDetails.Count
                         select a;
            return _query.Take(5).ToList();

        }
    }
}
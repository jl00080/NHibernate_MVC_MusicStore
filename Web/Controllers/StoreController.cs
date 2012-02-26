using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NHibernate;
using MvcMusicStore.Entities;
using NHibernate.Linq;

namespace MvcMusicStore.Controllers
{
    public class StoreController : Controller
    {
        ISession _session;

        public StoreController()
        {
            _session = MvcApplication.SessionFactory.GetCurrentSession(); 
        }

        //
        // GET: /Store/

        public ActionResult Index()
        {
            var genres = (from g in _session.Query<NHGenre>()
                          select g).ToList <NHGenre>();

            return View(genres);
        }

        //
        // GET: /Store/Browse?genre=Disco

        public ActionResult Browse(string genre)
        {
            // Retrieve Genre and its Associated Albums from database
            var genreModel = (from g in _session.Query<NHGenre>()
                              where g.Name == genre
                              select g).FirstOrDefault<NHGenre>();
            if (genreModel == null)
            {
                genreModel = new NHGenre { Name = genre };//"No Matching Genre Records" };
            }

            return View(genreModel);
        }

        //
        // GET: /Store/Details/5

        public ActionResult Details(int id) 
        {
            var album = _session.Get<NHAlbum>(id);

            return View(album);
        }

        //
        // GET: /Store/GenreMenu

        [ChildActionOnly]
        public ActionResult GenreMenu()
        {
            var genres = (from g in _session.Query<NHGenre>()
                         select g).ToList<NHGenre>();

            return PartialView(genres);
        }

    }
}
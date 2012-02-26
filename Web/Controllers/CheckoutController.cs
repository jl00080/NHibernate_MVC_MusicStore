using System;
using System.Linq;
using System.Web.Mvc;
using MvcMusicStore.Models;
using MvcMusicStore.Entities;
using NHibernate;
using NHibernate.Linq;
using MvcMusicStore.Infrastructure;

namespace MvcMusicStore.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        const string PromoCode = "FREE";

        ISession _session;
        public CheckoutController()
        {
            _session = MvcApplication.SessionFactory.GetCurrentSession(); 
        }

        //
        // GET: /Checkout/AddressAndPayment

        public ActionResult AddressAndPayment()
        {
            return View();
        }

        //
        // POST: /Checkout/AddressAndPayment
        [TransactionFilter]
        [HttpPost]
        public ActionResult AddressAndPayment(FormCollection values)
        {
            var order = new NHOrder();
            TryUpdateModel(order);

            //try
            //{
                if (string.Equals(values["PromoCode"], PromoCode,
                    StringComparison.OrdinalIgnoreCase) == false)
                {
                    return View(order as Order);
                }
                else
                {
                    order.Username = User.Identity.Name;
                    order.OrderDate = DateTime.Now;

                    //Save Order
                    _session.SaveOrUpdate(order);

                    //Process the order
                    var cart = ShoppingCart.GetCart(this.HttpContext);
                    cart.CreateOrder(order);

                    return RedirectToAction("Complete",
                        new { id = order.Id });
                }

            //}
            //catch
            //{
            //    //Invalid - redisplay with errors
            //    return View(order as Order);
            //}
        }

        //
        // GET: /Checkout/Complete
        [TransactionFilter]
        public ActionResult Complete(int id)
        {
            // Validate customer owns this order
            bool isValid = //_session.QueryOver<NHOrder>().Where(o => o.Id == id && o.Username == User.Identity.Name);
                (from o in _session.Query<NHOrder>()
                where o.Id == id && o.Username == User.Identity.Name
                select o).Any();
                //storeDB.Orders.Any(
                //o => o.OrderId == id &&
                //o.Username == User.Identity.Name);

            if (isValid)
            {
                return View(id);
            }
            else
            {
                return View("Error");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NHibernate;
using MvcMusicStore.Entities;
using NHibernate.Linq;
using MvcMusicStore.Infrastructure;

namespace MvcMusicStore.Models
{
    public partial class ShoppingCart
    {
        ISession _session;

        public ShoppingCart()
        {
            _session = MvcApplication.SessionFactory.GetCurrentSession(); 
        }

        string ShoppingCartId { get; set; }

        public const string CartSessionKey = "CartId";

        public static ShoppingCart GetCart(HttpContextBase context)
        {
            var cart = new ShoppingCart();
            cart.ShoppingCartId = cart.GetCartId(context);
            return cart;
        }

        // Helper method to simplify shopping cart calls
        public static ShoppingCart GetCart(Controller controller)
        {
            return GetCart(controller.HttpContext);
        }

        public void AddToCart(NHAlbum album)
        {
            // Get the matching cart and album instances
            var cartItem = _session.QueryOver<NHCart>().Where(
                c => c.CartId == ShoppingCartId
                && c.AlbumId == album.Id).SingleOrDefault();

            if (cartItem == null)
            {
                // Create a new cart item if no cart item exists
                cartItem = new NHCart
                {
                    AlbumId = album.Id,
                    CartId = ShoppingCartId,
                    Count = 1,
                    DateCreated = DateTime.Now
                };
            }
            else
            {
                // If the item does exist in the cart, then add one to the quantity
                cartItem.Count++;
            }

            // Save changes
            _session.SaveOrUpdate(cartItem);
        }

        public int RemoveFromCart(int id)
        {
            // Get the cart
            var cartItem
                = _session.QueryOver<NHCart>().Where(
                c => c.CartId == ShoppingCartId
                && c.Id == id).SingleOrDefault();

            int itemCount = 0;

            if (cartItem != null)
            {
                if (cartItem.Count > 1)
                {
                    cartItem.Count--;
                    itemCount = cartItem.Count;
                    // Save changes
                    _session.SaveOrUpdate(cartItem); ;
                }
                else
                {
                    _session.Delete(cartItem);
                }
            }

            return itemCount;
        }

        public void EmptyCart()
        {
            var cartItems = _session.QueryOver<NHCart>().Where(cart => cart.CartId == ShoppingCartId).List();

            foreach (var cartItem in cartItems)
            {
                _session.Delete(cartItem);
            }
        }

        public IList<NHCart> GetCartItems()
        {
            return _session.QueryOver<NHCart>().Where(cart => cart.CartId == ShoppingCartId).List();  
        }

        public int GetCount()
        {
            // Get the count of each item in the cart and sum them up
            int? count = (from cartItems in _session.Query<NHCart>()
                          where cartItems.CartId == ShoppingCartId
                          select (int?)cartItems.Count).Sum();
                
            // Return 0 if all entries are null
            return count ?? 0;
        }

        public decimal GetTotal()
        {
            // Multiply album price by count of that album to get 
            // the current price for each of those albums in the cart
            // sum all album price totals to get the cart total
            decimal? total = (from cartItems in _session.Query<NHCart>()
                              where cartItems.CartId == ShoppingCartId
                              select (int?)cartItems.Count * cartItems.Album.Price).Sum();
            return total ?? decimal.Zero;
        }

        
        public int CreateOrder(NHOrder order)
        {
            decimal orderTotal = 0;

            var cartItems = GetCartItems();

            // Iterate over the items in the cart, adding the order details for each
            foreach (var item in cartItems)
            {
                var orderDetail = new NHOrderDetail
                {
                    AlbumId = item.AlbumId,
                    OrderId = order.Id,
                    UnitPrice = item.Album.Price,
                    Quantity = item.Count
                };

                // Set the order total of the shopping cart
                orderTotal += (item.Count * item.Album.Price);

                order.OrderDetails.Add(orderDetail);
            }

            // Set the order's total to the orderTotal count
            order.Total = orderTotal;

            // Save the order
            _session.SaveOrUpdate(order);

            // Empty the shopping cart
            EmptyCart();

            // Return the OrderId as the confirmation number
            return order.Id;
        }

        // We're using HttpContextBase to allow access to cookies.
        public string GetCartId(HttpContextBase context)
        {
            if (context.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session[CartSessionKey] = context.User.Identity.Name;
                }
                else
                {
                    // Generate a new random GUID using System.Guid class
                    Guid tempCartId = Guid.NewGuid();

                    // Send tempCartId back to client as a cookie
                    context.Session[CartSessionKey] = tempCartId.ToString();
                }
            }

            return context.Session[CartSessionKey].ToString();
        }

        // When a user has logged in, migrate their shopping cart to
        // be associated with their username
        public void MigrateCart(string userName)
        {
            var shoppingCart = _session.QueryOver<NHCart>().Where(c => c.CartId == ShoppingCartId).List();

            foreach (NHCart item in shoppingCart)
            {
                item.CartId = userName;
            }
        }

    }
}
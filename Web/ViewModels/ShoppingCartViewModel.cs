using System.Collections.Generic;
using MvcMusicStore.Entities;

namespace MvcMusicStore.ViewModels
{
    public class ShoppingCartViewModel
    {
        public IList<NHCart> CartItems { get; set; }
        public decimal CartTotal { get; set; }
    }
}
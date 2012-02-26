using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MvcMusicStore.Entities
{
    public partial class NHOrder : Entity
    {
        //public int OrderId { get; private set; }

        public virtual System.DateTime OrderDate { get; set; }

        public virtual string Username { get; set; }

        public virtual string FirstName { get; set; }

        public virtual string LastName { get; set; }

        public virtual string Address { get; set; }

        public virtual string City { get; set; }

        public virtual string State { get; set; }

        public virtual string PostalCode { get; set; }

        public virtual string Country { get; set; }

        public virtual string Phone { get; set; }

        public virtual string Email { get; set; }

        public virtual decimal Total { get; set; }

        public virtual IList<NHOrderDetail> OrderDetails { get; set; }

        public NHOrder()
        {
            OrderDetails = new List<NHOrderDetail>();
        }
    }
}

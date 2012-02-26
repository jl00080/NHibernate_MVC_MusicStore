using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using MvcMusicStore.Entities;

namespace MvcMusicStore.Models
{
    [Bind(Exclude = "Id")]
    public partial class Order : NHOrder
    {
        [ScaffoldColumn(false)]
        public virtual int Id { get; set; }

        [ScaffoldColumn(false)]
        public override System.DateTime OrderDate { get; set; }

        [ScaffoldColumn(false)]
        public override string Username { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [DisplayName("First Name")]
        [StringLength(160)]
        public override string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [DisplayName("Last Name")]
        [StringLength(160)]
        public override string LastName { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [StringLength(70)]
        public override string Address { get; set; }

        [Required(ErrorMessage = "City is required")]
        [StringLength(40)]
        public override string City { get; set; }

        [Required(ErrorMessage = "State is required")]
        [StringLength(40)]
        public override string State { get; set; }

        [Required(ErrorMessage = "Postal Code is required")]
        [DisplayName("Postal Code")]
        [StringLength(10)]
        public override string PostalCode { get; set; }

        [Required(ErrorMessage = "Country is required")]
        [StringLength(40)]
        public override string Country { get; set; }

        [Required(ErrorMessage = "Phone is required")]
        [StringLength(24)]
        public override string Phone { get; set; }

        [Required(ErrorMessage = "Email Address is required")]
        [DisplayName("Email Address")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",
            ErrorMessage = "Email is is not valid.")]
        [DataType(DataType.EmailAddress)]
        public override string Email { get; set; }

        [ScaffoldColumn(false)]
        public override decimal Total { get; set; }

    }
}

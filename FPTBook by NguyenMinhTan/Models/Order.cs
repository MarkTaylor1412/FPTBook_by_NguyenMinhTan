using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using static FPTBook_by_NguyenMinhTan.Models.Cart;

namespace FPTBook_by_NguyenMinhTan.Models
{
	public class Order
	{
		[BindNever]
		public int OrderID { get; set; }

		[BindNever]
		public ICollection<CartLine> Lines { get; set; } = new List<CartLine>();

		[Required(ErrorMessage = "Please input your full name.")]
		public string? Name { get; set; }

		[Required(ErrorMessage = "Please input your phone number.")]
		public int? Phone { get; set; }

		[Required(ErrorMessage = "Please input your Email address.")]
		public string? Email { get; set; }

		[Required(ErrorMessage = "Please input your address.")]
		public string? Address { get; set; }

		[Required(ErrorMessage = "Please input your city.")]
		public string? City { get; set; }

		[Required(ErrorMessage = "Please input your province.")]
		public string? Province { get; set; }
		public int? PostalCode { get; set; }

		[Required(ErrorMessage = "Please input your country.")]
		public string? Country { get; set; }
		public bool GiftWrap { get; set; }

		[BindNever]
		public bool Shipped { get; set; }
	}
}

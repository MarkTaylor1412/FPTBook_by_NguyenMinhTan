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

		[Required(ErrorMessage = "Your name?")]
		public string? Name { get; set; }

		[Required(ErrorMessage = "Your address?")]
		public string? Line1 { get; set; }
		public string? Line2 { get; set; }
		public string? Line3 { get; set; }

		[Required(ErrorMessage = "Your city?")]
		public string? City { get; set; }

		[Required(ErrorMessage = "Your state?")]
		public string? State { get; set; }
		public string? Zip { get; set; }

		[Required(ErrorMessage = "Your country?")]
		public string? Country { get; set; }
		public bool GiftWrap { get; set; }

		[BindNever]
		public bool Shipped { get; set; }
	}
}

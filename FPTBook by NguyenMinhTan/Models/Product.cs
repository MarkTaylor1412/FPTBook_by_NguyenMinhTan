using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FPTBook_by_NguyenMinhTan.Models
{
	public class Product
	{
		public long? ProductID { get; set; }

		[Required(ErrorMessage = "This field is required.")]
		public string? ProductName { get; set; }

		[Required(ErrorMessage = "This field is required.")]
		public string ProductCategory { get; set; } = String.Empty;

		[Required]
		[Range(0.01, double.MaxValue, ErrorMessage = "This field is required.")]
		[Column(TypeName = "decimal(8, 2)")]
		public decimal ProductPrice { get; set;}

		public int ProductQuantity { get; set; }

		public string? ProductDescription { get; set; }
	}
}

using System.ComponentModel.DataAnnotations.Schema;

namespace FPTBook_by_NguyenMinhTan.Models
{
	public class Product
	{
		public long? ProductID { get; set; }

		public string? ProductName { get; set; }

		public string ProductCategory { get; set; } = String.Empty;

		[Column(TypeName = "decimal(8, 2)")]
		public decimal ProductPrice { get; set;}

		public int ProductQuantity { get; set; }

		public string? ProductDescription { get; set; }
	}
}

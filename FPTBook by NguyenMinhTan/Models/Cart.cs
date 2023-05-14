using Microsoft.Identity.Client;

namespace FPTBook_by_NguyenMinhTan.Models
{
	public class Cart
	{
		public List<CartLine> Lines { get; set; } = new List<CartLine>();

		public virtual void AddToCart(Product product, int quantity)
		{
			CartLine? line = Lines
				.Where(p  => p.Product.ProductID == product.ProductID)
				.FirstOrDefault();

			if (line == null)
			{
				Lines.Add(new CartLine
				{
					Product = product,
					ItemQuantity = quantity,
				});
			}
				else
				{
					line.ItemQuantity += quantity;
				}
		}

		public virtual void RemoveLine(Product product) =>
				Lines.RemoveAll(l => l.Product.ProductID == product.ProductID);

		public decimal ComputeTotalValue() =>
			Lines.Sum(e => e.Product.ProductPrice * e.ItemQuantity);

		public virtual void ClearLine() => Lines.Clear();

		public class CartLine
		{
			public int CartLinetID { get; set;}

			public Product Product { get; set; } = new();

			public int ItemQuantity { get; set; }
		}
	}
}

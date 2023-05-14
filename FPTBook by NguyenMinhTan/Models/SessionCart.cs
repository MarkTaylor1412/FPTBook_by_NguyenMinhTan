using System.Text.Json.Serialization;
using Azure.Core;
using FPTBook_by_NguyenMinhTan.Infrastructure;

namespace FPTBook_by_NguyenMinhTan.Models
{
	public class SessionCart : Cart
	{
		public static Cart GetCart(IServiceProvider services)
		{
			ISession? session = services.GetRequiredService<IHttpContextAccessor>()
				.HttpContext?.Session;
			SessionCart cart = session?.GetJson<SessionCart>("Cart")
				?? new SessionCart();
			cart.Session = session;
			return cart;
		}

		[JsonIgnore]
		public ISession? Session { get; set; }

		public override void AddToCart(Product product, int quantity)
		{
			base.AddToCart(product, quantity);
			Session?.SetJson("Cart", this);
		}

		public override void RemoveLine(Product product)
		{
			base.RemoveLine(product);
			Session?.SetJson("Cart", this);
		}

		public override void ClearLine()
		{
			base.ClearLine();
			Session?.Remove("Cart");
		}
	}
}

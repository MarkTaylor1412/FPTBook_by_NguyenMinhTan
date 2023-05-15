using Microsoft.AspNetCore.Mvc;
using FPTBook_by_NguyenMinhTan.Models;

namespace FPTBook_by_NguyenMinhTan.Controllers
{
	public class OrderController : Controller
	{
		private IOrderRepository repository;

		private Cart cart;

		public OrderController(IOrderRepository repoService, Cart cartService)
		{
			repository = repoService;
			cart = cartService;
		}

		public ViewResult Checkout() => View(new Order());

		[HttpPost]
		public IActionResult Checkout(Order order)
		{
			if (cart.Lines.Count()  == 0)
			{
				ModelState.AddModelError("", "Your cart is empty.");
			}
			if (ModelState.IsValid)
			{
				order.Lines = cart.Lines.ToArray();
				repository.SaveOrder(order);
				cart.ClearLine();
				return RedirectToPage("/Completed", new {orderId = order.OrderID});
			}
			else
			{
				return View();
			}
		}
	}
}

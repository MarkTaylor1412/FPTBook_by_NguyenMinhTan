using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FPTBook_by_NguyenMinhTan.Infrastructure;
using FPTBook_by_NguyenMinhTan.Models;

namespace FPTBook_by_NguyenMinhTan.Pages
{
    public class CartModel : PageModel
    {
        private IStoreRepository repository;

        public CartModel(IStoreRepository repo, Cart cartService)
        {
            repository = repo;
            Cart = cartService;
        }

        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; } = "/";

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }

        public IActionResult OnPost(long productId, string returnUrl)
        {
            Product? product = repository.Products
                .FirstOrDefault(p => p.ProductID == productId);

            if (product != null)
            {
                //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
                Cart.AddToCart(product, 1);
                //HttpContext.Session.SetJson("cart", Cart);
            }

            return RedirectToPage(new {returnUrl = returnUrl});
        }

        public IActionResult OnPostRemove(long productId, string returnUrl)
        {
            Cart.RemoveLine(Cart.Lines.First(cl => cl.Product.ProductID == productId).Product);
            return RedirectToPage(new {returnUrl = returnUrl});
        }
    }
}

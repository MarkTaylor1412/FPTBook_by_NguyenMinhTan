using FPTBook_by_NguyenMinhTan.Models;
using Microsoft.AspNetCore.Mvc;

namespace FPTBook_by_NguyenMinhTan.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IStoreRepository repository;

        public NavigationMenuViewComponent(IStoreRepository repo)
        {
            repository = repo;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(repository.Products
                .Select(x => x.ProductCategory)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}

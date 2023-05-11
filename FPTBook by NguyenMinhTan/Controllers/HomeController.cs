using Azure.Core.Pipeline;
using FPTBook_by_NguyenMinhTan.Models;
using FPTBook_by_NguyenMinhTan.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;
using System.Diagnostics;

namespace FPTBook_by_NguyenMinhTan.Controllers
{
	public class HomeController : Controller
	{
		private IStoreRepository repository;

		public int PageSize = 4;

		public HomeController(IStoreRepository repo)
		{
			repository = repo;
		}

		public ViewResult Index(string? category, int ProductPage = 1)
			=> View(new ProductsListViewModel
			{
				Products = repository.Products
				.Where(p => category == null || p.ProductCategory == category)
				.OrderBy(p => p.ProductID)
				.Skip((ProductPage - 1) * PageSize)
				.Take(PageSize),

				PagingInfo = new PagingInfo
				{
					CurrentPage = ProductPage,
					ItmesPerPage = PageSize,
					TotalItems = category == null ? repository.Products.Count() : repository.Products.Where(e => e.ProductCategory == category).Count()
				},

				CurrentCategory = category
			});
	}
}
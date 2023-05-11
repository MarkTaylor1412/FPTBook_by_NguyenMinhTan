using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace FPTBook_by_NguyenMinhTan.Models
{
	public class EFStoreRepository : IStoreRepository
	{
		private StoreDbContext context;
		public EFStoreRepository(StoreDbContext ctx) {
			context = ctx;
		}

		public IQueryable<Product> Products => context.Products;
	}
}

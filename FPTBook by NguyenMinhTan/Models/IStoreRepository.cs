namespace FPTBook_by_NguyenMinhTan.Models
{
	public interface IStoreRepository
	{
		IQueryable<Product> Products { get; }

		void CreateProduct(Product p);

		void DeleteProduct(Product p);

		void SaveProduct(Product p);
	}
}

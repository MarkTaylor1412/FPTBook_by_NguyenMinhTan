namespace FPTBook_by_NguyenMinhTan.Models
{
	public interface IStoreRepository
	{
		IQueryable<Product> Products { get; }
	}
}

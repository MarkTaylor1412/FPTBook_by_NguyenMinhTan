using System.Runtime.CompilerServices;

namespace FPTBook_by_NguyenMinhTan.Models.ViewModels
{
	public class PagingInfo
	{
		public int TotalItems { get; set; }
		
		public int ItmesPerPage { get; set; }

		public int CurrentPage { get; set; }

		public int TotalPages => (int)Math.Ceiling((decimal)TotalItems / ItmesPerPage);
	}
}

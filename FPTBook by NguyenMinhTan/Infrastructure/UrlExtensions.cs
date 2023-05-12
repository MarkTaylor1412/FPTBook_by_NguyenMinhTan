namespace FPTBook_by_NguyenMinhTan.Infrastructure
{
	public static class UrlExtensions
	{
		public static string ToUrl(this HttpRequest request) =>
			request.QueryString.HasValue
				? $"{request.Path}{request.QueryString}"
				: request.Path.ToString();
	}
}

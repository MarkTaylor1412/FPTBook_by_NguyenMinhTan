﻿using Microsoft.EntityFrameworkCore;

namespace FPTBook_by_NguyenMinhTan.Models
{
	public class StoreDbContext : DbContext
	{
		public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options) { }

		public DbSet<Product> Products => Set<Product>();
	}
}
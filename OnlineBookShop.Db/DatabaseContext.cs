using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Db
{
	public class DatabaseContext : DbContext
	{
		//Доступ к таблицам
		public DbSet<Product> Products { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// Настройка первичного ключа для сущности Product
			modelBuilder.Entity<Product>(entity =>
			{
				entity.HasKey(e => e.Id);
			});
		}

		public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) 
		{
			Database.EnsureCreated(); // Для создания базы данных при первом обращении
		}
	}
}

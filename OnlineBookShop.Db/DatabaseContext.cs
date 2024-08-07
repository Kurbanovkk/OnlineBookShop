using Microsoft.EntityFrameworkCore;
using OnlineBookShop.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookShop.Db
{
	public class DatabaseContext : DbContext
	{
		//Доступ к таблицам
		public DbSet<Product> Products { get; set; }
		public DbSet<Cart> Carts { get; set; }
		public DbSet<CartItem> CartItems { get; set; }

		public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) 
		{
			Database.EnsureCreated(); // Для создания базы данных при первом обращении
		}
	}
}

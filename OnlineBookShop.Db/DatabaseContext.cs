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

		public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) 
		{
			Database.EnsureCreated(); // Для создания базы данных при первом обращении
		}
	}
}

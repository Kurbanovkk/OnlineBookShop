using OnlineBookShop;
using Serilog;
using Microsoft.EntityFrameworkCore;
using OnlineBookShop.Db;
using Microsoft.Extensions.DependencyInjection.Extensions;
using OnlineBookShop.Db.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// �������� ������ ����������� �� ����� ������������
string connection = builder.Configuration.GetConnectionString("online_book_shop");
// �������� �������� MobileContext � �������� ������� � ����������
builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connection));
builder.Services.AddSingleton<IUsersRepository, InMemoryUsersRepository>();
builder.Services.AddTransient<IProductsRepository, ProductsDbRepository>();
builder.Services.AddTransient<ICartsRepository, CartsDbRepository>();
builder.Services.AddSingleton<IOrdersRepository, InMemoryOrdersRepository>();
builder.Services.AddSingleton<IFavouritesRepository, FavouritesDbRepository>();
builder.Services.AddSingleton<IRolesRepository, InMemoryRolesRepository>();
builder.Services.AddControllersWithViews();
builder.Host.UseSerilog((context, configuration) => configuration
.ReadFrom.Configuration(context.Configuration)
.Enrich.WithProperty("ApplicationName", "OnlineBookShop"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSerilogRequestLogging();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "Administrator",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

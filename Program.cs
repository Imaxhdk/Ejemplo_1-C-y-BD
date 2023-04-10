
using Ejemplo_1.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//para la base de datos
builder.Services.AddDbContext<DbCrudContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("ConexionDb"), Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.25-mariadb")));  




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

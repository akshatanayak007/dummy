using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OnlineBook.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<OnlineBookContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("OnlineBookContext") ?? throw new InvalidOperationException("Connection string 'OnlineBookContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

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
    pattern: "{controller=Books}/{action=Index}/{id?}");

app.Run();

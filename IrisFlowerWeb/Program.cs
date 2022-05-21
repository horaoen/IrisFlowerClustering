using IrisFlowerWeb.DataBase;
using IrisFlowerWeb.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
var configuration = builder.Configuration;
// Add services to the container.
services.AddRazorPages();
services.AddDbContextPool<AppDbContext>(options =>
{
    options.UseMySql(configuration["ConnectionStrings:MySql"],
        new MySqlServerVersion(new Version(8, 0, 27)));
});

#region  DI
services.AddScoped<IIrisDataRepository, IrisDataRepository>();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
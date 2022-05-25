using Microsoft.Extensions.ML;

using IrisFlowerWeb.Models;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<IrisFlowerContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("IrisFlowerContext") ?? throw new InvalidOperationException("Connection string 'IrisFlowerContext' not found.")));

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddPredictionEnginePool<IrisFlowerData, IrisFlowerPrediction>()
    .FromFile(
        modelName: "IrisClusteringModel", 
        filePath: "MLModels/IrisClusteringModel.zip", 
        watchForChanges: true);


var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

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
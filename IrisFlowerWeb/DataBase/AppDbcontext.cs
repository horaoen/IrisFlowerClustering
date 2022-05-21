using IrisFlowerWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace IrisFlowerWeb.DataBase;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<IrisData> IrisDatas { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}
using Microsoft.EntityFrameworkCore;

public class IrisFlowerContext : DbContext
{
    public IrisFlowerContext(DbContextOptions<IrisFlowerContext> options)
        : base(options)
    {
    }

    public DbSet<IrisFlowerWeb.Models.IrisFlower>? IrisFlower { get; set; }
}
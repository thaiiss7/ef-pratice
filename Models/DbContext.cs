using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

public class PraticeDbContext(DbContextOptions opts) : DbContext(opts)
{
    public DbSet<Sale> Sales => Set<Sale>();
    public DbSet<UserData> UserDatas => Set<UserData>();
    public DbSet<ProductItem> ProductItems => Set<ProductItem>();

    protected override void OnModelCreating(ModelBuilder model)
    {
        model.Entity<ProductItem>();
        model.Entity<UserData>();

        model.Entity<Sale>()
            .HasOne(s => s.UserData)
            .WithMany(u => u.Sales)
            .HasForeignKey(s => s.UserDataID)
            .OnDelete(DeleteBehavior.Cascade);

        model.Entity<Sale>()
            .HasOne(s => s.ProductItem)
            .WithMany(p => p.Sales)
            .HasForeignKey(s => s.ProductItemID)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
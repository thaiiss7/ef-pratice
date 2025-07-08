using Microsoft.VisualBasic;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using System.Net;
using Microsoft.VisualBasic.ApplicationServices;

/*
public class Database
{
    static async Task CreateContext()
    {
        var connBuilder = new SqlConnectionStringBuilder
        {
            DataSource = "localhost",
            InitialCatalog = "SalesDB",
            IntegratedSecurity = true,
            TrustServerCertificate = true
        };
        var stringConnection = connBuilder.ToString();

        var optsBuilder = new DbContextOptionsBuilder();
        optsBuilder.UseSqlServer(stringConnection);
        var options = optsBuilder.Options;

        var db = new SalesDbContext(options);
        await db.Database.EnsureCreatedAsync();

        await db.SaveChangesAsync();

        public class SalesDbContext(DbContextOptions opts) : DbContext(opts)
    {
        public DbSet<ProductItem> ProductItems => Set<ProductItem>();
        public DbSet<Sale> Sales => Set<Sale>();
        public DbSet<UserData> UserDatas => Set<UserData>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductItem>();

            modelBuilder.Entity<UserData>();

            modelBuilder.Entity<Sale>()
                .HasOne(s => s.ProductItem)
                .WithMany(p => p.Sales)
                .HasForeignKey(s => s.ProductItemID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Sale>()
                .HasOne(s => s.UserData)
                .WithMany(u => u.Sales)
                .HasForeignKey(s => s.UserDataID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
        
        return db;
    }
}*/
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

// namespace MyProject
// {
    public class Database
    {
        public async Task<PraticeDbContext> Create()
        {

            var connBuilder = new SqlConnectionStringBuilder
            {
                DataSource = "localhost",
                InitialCatalog = "pratice",
                IntegratedSecurity = true,
                TrustServerCertificate = true
            };
            var stringConnection = connBuilder.ToString();

            var optsBuilder = new DbContextOptionsBuilder();
            optsBuilder.UseSqlServer(stringConnection);
            var options = optsBuilder.Options;

            var db = new PraticeDbContext(options);
            await db.Database.EnsureCreatedAsync();

            return db;
        }
    }

// }
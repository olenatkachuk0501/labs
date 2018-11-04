using Microsoft.EntityFrameworkCore;

namespace SqlServerEFSample
{
    public class EFSampleContext : DbContext
    {
        string _connectionString;

        public EFSampleContext(string connectionString)
        {
            this._connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this._connectionString);
        }

        public DbSet<University> Universities { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
    }
}

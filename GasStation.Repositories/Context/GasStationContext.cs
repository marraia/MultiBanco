using GasStation.Domain.Entities;
using GasStation.Repositories.Configuration.Mapping.NpgPost;
using GasStation.Repositories.Configuration.Mapping.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GasStation.Repositories.Context
{
    public class GasStationContext : DbContext
    {
        private readonly string _databaseDefault;
        public GasStationContext
        (
            DbContextOptions<GasStationContext> options,
            IConfiguration configuration
        ) : base(options)
        {
            _databaseDefault = configuration.GetSection("DefaultDatabase").Value;
        }

        public DbSet<Station> Station { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (_databaseDefault == "Postgres")
                ConfigModelCreatingNpgSql(modelBuilder);
            else
                ConfigModelCreatingSqlServer(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void ConfigModelCreatingNpgSql(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasPostgresExtension("citext")
                .ApplyConfiguration(new StationNpgSqlConfiguration());
        }

        private void ConfigModelCreatingSqlServer(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfiguration(new StationSqlServerConfiguration());
        }
    }
}

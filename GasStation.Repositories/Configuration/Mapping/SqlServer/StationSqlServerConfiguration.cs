using GasStation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GasStation.Repositories.Configuration.Mapping.SqlServer
{
    public class StationSqlServerConfiguration : IEntityTypeConfiguration<Station>
    {
        public void Configure(EntityTypeBuilder<Station> builder)
        {
            ConfigNameTable(builder);
            ConfigPrimaryKey(builder);
            ConfigProperties(builder);
            ConfigIdentity(builder);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        public void ConfigNameTable(EntityTypeBuilder<Station> builder)
        {
            builder
                .ToTable("station", "dbo");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        public void ConfigPrimaryKey(EntityTypeBuilder<Station> builder)
        {
            builder
                .HasKey(u => u.Id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        public void ConfigProperties(EntityTypeBuilder<Station> builder)
        {
            builder.Property(con => con.Id).HasColumnName("Id");
            builder.Property(con => con.Name).HasColumnName("Nome");
            builder.Property(con => con.Address).HasColumnName("Endereco");
            builder.Property(con => con.Phone).HasColumnName("Telefone");

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        private void ConfigIdentity(EntityTypeBuilder<Station> builder)
        {
            builder
                .Property(a => a.Id)
                .UseIdentityAlwaysColumn()
                .ValueGeneratedOnAdd();
        }
    }
}

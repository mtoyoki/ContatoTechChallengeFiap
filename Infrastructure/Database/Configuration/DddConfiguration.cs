using Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configuration
{
    public class DddConfiguration : IEntityTypeConfiguration<Ddd>
    {
        public void Configure(EntityTypeBuilder<Ddd> builder)
        {
            builder.ToTable("DDD");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnType("INT").IsRequired().ValueGeneratedNever();
            builder.Property(p => p.Regiao).HasColumnType("VARCHAR(100)").IsRequired();
        }
    }
}

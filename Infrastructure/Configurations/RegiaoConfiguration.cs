using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class RegiaoConfiguration : IEntityTypeConfiguration<Regiao>
    {
        public void Configure(EntityTypeBuilder<Regiao> builder)
        {
            builder.ToTable("REGIAO");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                   .HasColumnType("INT")
                   .IsRequired()
                   .ValueGeneratedNever();

            builder.Property(p => p.Descricao)
                   .HasColumnType("VARCHAR(100)")
                   .IsRequired();

            builder.Property(p => p.Uf)
                   .HasColumnType("VARCHAR(10)")
                   .IsRequired();
        }
    }
}
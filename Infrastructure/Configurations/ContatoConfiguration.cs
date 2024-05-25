using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class ContatoConfiguration : IEntityTypeConfiguration<Contato>
    {
        public void Configure(EntityTypeBuilder<Contato> builder)
        {
            builder.ToTable("CONTATO");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnType("INT").UseIdentityColumn();
            builder.Property(p => p.Nome).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(p => p.Telefone).HasColumnType("VARCHAR(20)").IsRequired();
            builder.Property(p => p.Email).HasColumnType("VARCHAR(50)");
            builder.Property(p => p.RegiaoId).HasColumnType("INT").IsRequired();

            //builder.HasOne(c => c.Regiao)
            //        .WithMany(r => r.Contatos)
            //        .HasPrincipalKey(r => r.Id);

            builder.HasOne(c => c.Regiao)
                   .WithMany()         
                   .HasForeignKey(c => c.RegiaoId);
        }
    }
}
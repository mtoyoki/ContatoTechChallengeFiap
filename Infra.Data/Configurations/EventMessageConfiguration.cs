using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Configurations
{
    public class EventMessageConfiguration : IEntityTypeConfiguration<EventMessage>
    {
        public void Configure(EntityTypeBuilder<EventMessage> builder)
        {
            builder.ToTable("EVENT_MESSAGE");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnType("INT")
                .UseIdentityColumn();

            builder.Property(p => p.EventMsgId)
                   .HasColumnType("uniqueidentifier")
                   .IsRequired()
                   .ValueGeneratedNever();

            builder.Property(p => p.EventMsg)
                .HasColumnType("VARCHAR(1000)");

            builder.Property(p => p.Result)
                .HasColumnType("VARCHAR(100)");

            builder.Property(p => p.Details)
                .HasColumnType("VARCHAR(2000)");
        }
    }
}
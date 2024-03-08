using api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Persistence.Contexts.Configurations
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(p => p.Nome).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Logotipo).IsRequired();
            builder.Property(p => p.Email).IsRequired().HasMaxLength(100);
            builder.HasMany(c => c.Logradouros)
            .WithOne(l => l.Cliente)
            .HasForeignKey(l => l.ClienteId);
        }
    }
}

using api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Persistence.Contexts.Configurations
{
    public class LogradouroConfiguration : IEntityTypeConfiguration<Logradouro>
    {
        public void Configure(EntityTypeBuilder<Logradouro> builder)
        {
            builder.ToTable("Logradouro");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(p => p.Endereco).IsRequired().HasMaxLength(100);            
        }
    }
}

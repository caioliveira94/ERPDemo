using ERPDemo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERPDemo.Data.EntityConfig
{
    public class EntityBaseConfig<T> : IEntityTypeConfiguration<T> where T : EntityBase
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnType("long")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.CreationDate)
                .HasColumnType("Datetime")
                .IsRequired();

            builder.Property(x => x.LastUpdate)
                .HasColumnType("Datetime");
        }
    }
}

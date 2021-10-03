using BlazorEF.Data.EF.Extensions;
using BlazorEF.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorEF.Data.EF.Configurations
{
    public class FunctionConfiguration : DbEntityConfiguration<Function>
    {
        public override void Configure(EntityTypeBuilder<Function> entity)
        {
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).IsRequired()
                .HasMaxLength(128).IsUnicode(false);
            //etc.

            //entity.Property(c => c.Id).HasMaxLength(128)
            //    .IsRequired().HasColumnType("varchar(128)");
        }
    }
}
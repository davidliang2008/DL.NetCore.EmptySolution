using DL.NetCore.EmptySolution.Data.EFCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DL.NetCore.EmptySolution.Data.EFCore.Configurations
{
    public class WorkPackageEntityConfiguration : IEntityTypeConfiguration<WorkPackageEntity>
    {
        public void Configure(EntityTypeBuilder<WorkPackageEntity> builder)
        {
            builder.ToTable("WorkPackage");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired();

            builder.HasOne(x => x.Parent)
                .WithMany(x => x.Children)
                .HasForeignKey(x => x.ParentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

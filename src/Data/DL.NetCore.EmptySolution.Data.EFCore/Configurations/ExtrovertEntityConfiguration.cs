using DL.NetCore.EmptySolution.Domain.SocialRelationship.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DL.NetCore.EmptySolution.Data.EFCore.Configurations
{
    public class ExtrovertEntityConfiguration : IEntityTypeConfiguration<Extrovert>
    {
        public void Configure(EntityTypeBuilder<Extrovert> builder)
        {
            builder.ToTable("Extrovert");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired();
        }
    }
}

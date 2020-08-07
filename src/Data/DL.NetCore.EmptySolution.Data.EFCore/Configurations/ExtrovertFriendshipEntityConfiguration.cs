using DL.NetCore.EmptySolution.Domain.SocialRelationship.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DL.NetCore.EmptySolution.Data.EFCore.Configurations
{
    public class ExtrovertFriendshipEntityConfiguration : IEntityTypeConfiguration<ExtrovertFriendship>
    {
        public void Configure(EntityTypeBuilder<ExtrovertFriendship> builder)
        {
            builder.HasKey(x => new { x.ExtrovertId, x.ExtrovertFriendId });

            builder.HasOne(x => x.Extrovert)
                .WithMany(x => x.Friends)
                .HasForeignKey(x => x.ExtrovertId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.ExtrovertFriend)
                .WithMany(x => x.FriendsOf)
                .HasForeignKey(x => x.ExtrovertFriendId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

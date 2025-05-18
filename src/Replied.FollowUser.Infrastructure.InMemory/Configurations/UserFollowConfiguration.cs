using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Replied.FollowUser.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Replied.FollowUser.Infrastructure.InMemory.Configurations;
public class UserFollowConfiguration : IEntityTypeConfiguration<UserFollow>
{
    public void Configure(EntityTypeBuilder<UserFollow> builder)
    {
        builder.HasKey(f => new { f.FollowerId, f.FolloweeId });

        builder.HasOne(f => f.Follower)
              .WithMany(u => u.Following)
              .HasForeignKey(f => f.FollowerId)
              .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(f => f.Followee)
              .WithMany(u => u.Followers)
              .HasForeignKey(f => f.FolloweeId)
              .OnDelete(DeleteBehavior.NoAction);
    }
}

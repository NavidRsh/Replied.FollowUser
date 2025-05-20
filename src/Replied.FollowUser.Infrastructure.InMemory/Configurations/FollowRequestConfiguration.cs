using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Replied.FollowUser.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Replied.FollowUser.Infrastructure.InMemory.Configurations;
public class FollowRequestConfiguration : IEntityTypeConfiguration<FollowRequest>
{
    public void Configure(EntityTypeBuilder<FollowRequest> builder)
    {
        builder.HasKey(u => u.Id);

        builder.Property(u => u.Status).IsConcurrencyToken();

        builder.HasOne(f => f.Follower)
            .WithMany(u => u.FollowRequests)
            .HasForeignKey(f => f.FollowerId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(f => f.Followee)
             .WithMany(u => u.FollowRequested)
             .HasForeignKey(f => f.FolloweeId)
             .OnDelete(DeleteBehavior.NoAction);
    }
}


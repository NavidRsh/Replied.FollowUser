using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Replied.FollowUser.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Replied.FollowUser.Infrastructure.InMemory.Configurations;
public class BlockedConfiguration : IEntityTypeConfiguration<Blocked>
{
    public void Configure(EntityTypeBuilder<Blocked> builder)
    {
        builder.HasKey(u => u.Id);

        builder.HasOne(f => f.User)
             .WithMany(u => u.BlockerUsers)
             .HasForeignKey(f => f.UserId)
             .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(f => f.BlockedUser)
             .WithMany(u => u.BlockedUsers)
             .HasForeignKey(f => f.BlockedUserId)
             .OnDelete(DeleteBehavior.NoAction);
    }
}

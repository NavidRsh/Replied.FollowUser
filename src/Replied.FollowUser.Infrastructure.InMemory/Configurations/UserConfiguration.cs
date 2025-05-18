using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Replied.FollowUser.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Replied.FollowUser.Infrastructure.InMemory.Configurations;
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);

        builder.Property(u => u.BirthDate)
              .HasConversion(
                  v => v.ToDateTime(TimeOnly.MinValue),
                  v => DateOnly.FromDateTime(v));

        builder.Property(u => u.FollowersCount)
            .IsConcurrencyToken();

        builder.Property(u => u.FollowingCount)
            .IsConcurrencyToken();

        #region Seeding Initial Data 
        builder.HasData(User.Create("Mat", new DateOnly(1990, 7, 6)));
        builder.HasData(User.Create("Mike", new DateOnly(1991, 8, 24)));
        builder.HasData(User.Create("Alice", new DateOnly(1992, 2, 21)));
        builder.HasData(User.Create("Patrice", new DateOnly(1993, 4, 05)));
        builder.HasData(User.Create("Micheal", new DateOnly(1986, 9, 17)));
        builder.HasData(User.Create("Ibrahim", new DateOnly(1989, 4, 1)));
        builder.HasData(User.Create("Vish", new DateOnly(1988, 3, 21)));
        builder.HasData(User.Create("Anni", new DateOnly(1999, 10, 18)));
        builder.HasData(User.Create("Roya", new DateOnly(2005, 11, 17)));
        builder.HasData(User.Create("Sagar", new DateOnly(2001, 11, 02)));
        #endregion
    }
}

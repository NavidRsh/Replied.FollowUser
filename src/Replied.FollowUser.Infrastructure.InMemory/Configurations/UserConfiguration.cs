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

        builder.Property(u => u.FollowingRequestsCount)
            .IsConcurrencyToken();

        #region Seeding Initial Data 
        builder.HasData(User.Create(Guid.Parse("11111111-1111-1111-1111-111111111111"),
            "Mat", new DateOnly(1990, 7, 6)));
        builder.HasData(User.Create(Guid.Parse("22222222-2222-2222-2222-222222222222"), 
            "Mike", new DateOnly(1991, 8, 24)));
        builder.HasData(User.Create(Guid.Parse("33333333-3333-3333-3333-333333333333"),
            "Alice", new DateOnly(1992, 2, 21)));
        builder.HasData(User.Create(Guid.Parse("44444444-4444-4444-4444-444444444444"),
            "Patrice", new DateOnly(1993, 4, 05)));
        builder.HasData(User.Create(Guid.Parse("55555555-5555-5555-5555-555555555555"),
            "Micheal", new DateOnly(1986, 9, 17)));
        builder.HasData(User.Create(Guid.Parse("66666666-6666-6666-6666-666666666666"),
            "Ibrahim", new DateOnly(1989, 4, 1)));
        builder.HasData(User.Create(Guid.Parse("77777777-7777-7777-7777-777777777777"),
            "Vish", new DateOnly(1988, 3, 21)));
        builder.HasData(User.Create(Guid.Parse("88888888-8888-8888-8888-888888888888"),
            "Anni", new DateOnly(1999, 10, 18)));
        builder.HasData(User.Create(Guid.Parse("99999999-9999-9999-9999-999999999999"),
            "Roya", new DateOnly(2005, 11, 17)));
        builder.HasData(User.Create(Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
            "Sagar", new DateOnly(2001, 11, 02)));
        #endregion
    }
}

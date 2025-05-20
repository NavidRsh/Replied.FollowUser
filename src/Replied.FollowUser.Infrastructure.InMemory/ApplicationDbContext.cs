using Microsoft.EntityFrameworkCore;
using Replied.FollowUser.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Replied.FollowUser.Infrastructure.InMemory;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<User> Users { get; set; }

    public DbSet<UserFollow> UserFollows { get; set; }

    public DbSet<FollowRequest> FollowRequests { get; set; }

    public DbSet<Blocked> Blocked { get; set; }

    protected static void ConfigureDbContext(ModelBuilder modelBuilder, 
        Assembly entitiesAssembly)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}

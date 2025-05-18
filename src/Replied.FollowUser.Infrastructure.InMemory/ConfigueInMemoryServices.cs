using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Replied.FollowUser.Infrastructure.InMemory;
public static class ConfigueInMemoryServices
{
    public static IServiceCollection AddEfServices(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("MyInMemoryDb"));
        
        //services.AddEfRepositories();

        return services;
    }

}

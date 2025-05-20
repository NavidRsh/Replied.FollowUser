using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Replied.FollowUser.Application.Contracts.Repositories;
using Replied.FollowUser.Infrastructure.InMemory.Repositories;

namespace Replied.FollowUser.Infrastructure.InMemory;
public static class ConfigueInMemoryServices
{
    public static IServiceCollection AddnMemoryServices(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("MyInMemoryDb"));
        
        services.AddRepositories();

        return services;
    }

    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserCommandRepository, UserCommandRepository>();

        services.AddScoped<IUserQueryRepository, UserQueryRepository>();        

        services.AddScoped<IUnitOfWork, UnitOfWork>(); 
    }   

}

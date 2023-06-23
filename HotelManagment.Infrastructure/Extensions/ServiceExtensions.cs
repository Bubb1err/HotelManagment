using HotelManagment.Core.Interfaces;
using HotelManagment.Infrastructure.Data;
using HotelManagment.Infrastructure.Repositories;
using HotelManagment.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HotelManagment.Infrastructure.Extensions;

public static class ServiceExtensions
{
  public static IServiceCollection ConfigureDbContext(this IServiceCollection serviceCollection, IConfiguration configuration)
  {
    string connectionString = configuration.GetConnectionString("DbContext")!;
    serviceCollection.AddDbContext<HotelDbContext>(options => options.UseSqlServer(connectionString));
    
    return serviceCollection;
  }

  public static IServiceCollection AddUserRepository(this IServiceCollection serviceCollection)
  {
    return serviceCollection.AddScoped<IUserRepository, UserRepository>();
  }

  public static IServiceCollection AddUserService(this IServiceCollection serviceCollection)
  {
    return serviceCollection.AddScoped<IUserService, UserService>();
  }
}
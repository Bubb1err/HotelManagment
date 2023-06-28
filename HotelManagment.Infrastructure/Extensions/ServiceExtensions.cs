using HotelManagment.Core.Interfaces;
using HotelManagment.Core.Interfaces.Repositories;
using HotelManagment.Core.Interfaces.Services;
using HotelManagment.Infrastructure.Data;
using HotelManagment.Infrastructure.Repositories;
using HotelManagment.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
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

  public static IServiceCollection ConfigureDefaultIdentity(this IServiceCollection serviceCollection)
  {
    serviceCollection
      .AddDefaultIdentity<IdentityUser>(options =>
      {
        options.User.RequireUniqueEmail = true;

        options.SignIn.RequireConfirmedPhoneNumber = false;
        options.SignIn.RequireConfirmedAccount = false;
        options.SignIn.RequireConfirmedEmail = false;

        options.Password.RequireLowercase = true;
        options.Password.RequireUppercase = true;
        options.Password.RequireNonAlphanumeric = true;
        options.Password.RequireDigit = true;
        options.Password.RequiredLength = 8;
        options.Password.RequiredUniqueChars = 0;
      })
      .AddEntityFrameworkStores<HotelDbContext>();

    return serviceCollection;
  }

  public static IServiceCollection ConfigureRepositories(this IServiceCollection serviceCollection)
  {
    serviceCollection.AddScoped<IUserRepository, UserRepository>();
    serviceCollection.AddScoped<IReportsRepository, ReportsRepository>();

    return serviceCollection;
  }
  public static IServiceCollection ConfigureServices(this IServiceCollection serviceCollection)
  {
    serviceCollection.AddScoped<IUserService, UserService>();
    serviceCollection.AddScoped<IReportsService, ReportsService>();
    
    return serviceCollection;
  }
}
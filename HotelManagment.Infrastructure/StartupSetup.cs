
using HotelManagment.Core.Interfaces;
using HotelManagment.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace HotelManagment.Infrastructure
{
  public static class StartupSetup
  {
    public static void RegisterRepositories(this IServiceCollection services)
    {
      services.AddScoped<IReportsRepository, ReportsRepository>();
    }
  }
}

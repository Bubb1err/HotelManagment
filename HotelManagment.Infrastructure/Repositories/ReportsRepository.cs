using HotelManagment.Core.Entities;
using HotelManagment.Core.Interfaces.Repositories;
using HotelManagment.Infrastructure.Data;

namespace HotelManagment.Infrastructure.Repositories;

internal class ReportsRepository : RepositoryBase<Report>, IReportsRepository
{
  public ReportsRepository(HotelDbContext dbContext) : base(dbContext) { }
}

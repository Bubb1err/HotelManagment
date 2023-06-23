using HotelManagment.Core.Entities;
using HotelManagment.Core.Interfaces;
using HotelManagment.Infrastructure.Data;

namespace HotelManagment.Infrastructure.Repositories
{
  public class ReportsRepository : RepositoryBase<Report>, IReportsRepository
  {
    public ReportsRepository(HotelDbContext dbContext) : base(dbContext)
    {
    }

    public void Update(Report report)
    {
     _db.Update(report);
    }
  }
}

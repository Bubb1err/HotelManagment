using HotelManagment.Core.Entities;

namespace HotelManagment.Core.Interfaces
{
  public interface IReportsRepository : IRepository<Report>
  {
    void Update(Report report);
  }
}

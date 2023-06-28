using HotelManagment.Core.Entities;
using HotelManagment.Core.Interfaces.Repositories;
using HotelManagment.Infrastructure.Data;

namespace HotelManagment.Infrastructure.Repositories;

internal class UserRepository : RepositoryBase<User>, IUserRepository
{
  public UserRepository(HotelDbContext dbContext) : base(dbContext) { }
}
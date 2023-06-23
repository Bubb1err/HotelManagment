using HotelManagment.Core.Entities;
using HotelManagment.Core.Interfaces;
using HotelManagment.Infrastructure.Data;

namespace HotelManagment.Infrastructure.Repositories;

public class UserRepository : RepositoryBase<User>, IUserRepository
{
  public UserRepository(HotelDbContext dbContext) : base(dbContext) { }
}
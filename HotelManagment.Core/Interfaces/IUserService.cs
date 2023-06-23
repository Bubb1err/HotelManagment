using HotelManagment.Core.Entities;

namespace HotelManagment.Core.Interfaces;

public interface IUserService
{
  Task<Result<User>> FindByIdAsync(string id);
  Task<Result<User>> FindByUsernameAsync(string username);
  Task<Result<User>> FindByEmailAsync(string email);

  Result Create(User user);
  Result Update(User user);
  Result Delete(User user);
}
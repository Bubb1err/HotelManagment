using HotelManagment.Core.Entities;

namespace HotelManagment.Core.Interfaces;

public interface IUserService
{
  Result<IEnumerable<User>> GetAll();
  
  Task<Result<User>> FindByIdAsync(string id);
  Task<Result<User>> FindByUsernameAsync(string username);
  Task<Result<User>> FindByEmailAsync(string email);

  Task<Result> CreateAsync(User user);
  Task<Result> UpdateAsync(User user);
  Task<Result> DeleteAsync(User user);
}
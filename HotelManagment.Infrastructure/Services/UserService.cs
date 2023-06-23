using HotelManagment.Core.Entities;
using HotelManagment.Core.Interfaces;

namespace HotelManagment.Infrastructure.Services;

public class UserService : IUserService
{
  private readonly IUserRepository _userRepository;

  public UserService(IUserRepository userRepository)
  {
    _userRepository = userRepository;
  }
  
  public async Task<Result<User>> FindByIdAsync(string id)
  {
    User? user = await _userRepository.TryFindAsync(user => user.Id == id);
    if (user is null)
    {
      Result<User> result = Result<User>.Failure("error");
      return result;
    }

    return Result<User>.Succeeded(user);
  }

  public async Task<Result<User>> FindByUsernameAsync(string username)
  {
    User? user = await _userRepository.TryFindAsync(user => user.Id == username);
    if (user is null)
    {
      Result<User> result = Result<User>.Failure("error");
      return result;
    }

    return Result<User>.Succeeded(user);
  }

  public async Task<Result<User>> FindByEmailAsync(string email)
  {
    User? user = await _userRepository.TryFindAsync(user => user.Id == email);
    if (user is null)
    {
      Result<User> result = Result<User>.Failure("error");
      return result;
    }

    return Result<User>.Succeeded(user);
  }

  public Result Create(User user)
  {
    _userRepository.CreateAsync(user);

    return Result.Succeeded();
  }

  public Result Update(User user)
  {
    _userRepository.UpdateAsync(user);
    
    return Result.Succeeded();
  }

  public Result Delete(User user)
  {
    _userRepository.DeleteAsync(user);

    return Result.Succeeded();
  }
}
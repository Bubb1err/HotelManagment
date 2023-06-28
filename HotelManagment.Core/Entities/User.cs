using HotelManagment.Core.Enums;

namespace HotelManagment.Core.Entities;

public sealed class User
{
  public string Id { get; set; } = string.Empty; 
  public string Username { get; set; } = string.Empty; 
  public string Email { get; set; } = string.Empty; 
  public string Phone { get; set; } = string.Empty;
  public string FirstName { get; set; } = string.Empty;
  public string LastName { get; set; } = string.Empty;
  public EmploeeType Type { get; set; }
}
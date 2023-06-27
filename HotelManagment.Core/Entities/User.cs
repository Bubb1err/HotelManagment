using HotelManagment.Core.Enums;

namespace HotelManagment.Core.Entities;

public sealed class User
{
  public string Id { get; set; } 
  public string Username { get; set; } 
  public string Email { get; set; } 
    public string Phone { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public EmploeeType Type { get; set; }
    public User()
    {
        Id = string.Empty;
        Username= string.Empty;
        Email = string.Empty;
        Phone = string.Empty;
        FirstName = string.Empty;
        LastName = string.Empty;
    }

}
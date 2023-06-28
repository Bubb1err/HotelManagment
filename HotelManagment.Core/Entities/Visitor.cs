using HotelManagment.Core.Enums;

namespace HotelManagment.Core.Entities;

public class Visitor
{
  public int Id { get; set; }
  public string FirstName { get; set; } = string.Empty;
  public string LastName { get; set; } = string.Empty;
  public string Phone { get; set; } = string.Empty;
}


using HotelManagment.Core.Enums;

namespace HotelManagment.Core.Entities;

public class Visitor
{
  public int Id { get; set; }
  public string FirstName { get; set; }
  public string LastName { get; set; }
  public string Phone { get; set; }
  public string PassportId { get; set; }
  public VisitorState State { get; set; }

  // Relations
  public int? RoomId { get; set; }
  public Room? Room { get; set; }
}


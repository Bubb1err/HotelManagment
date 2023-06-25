namespace HotelManagment.Core.Entities;

public class Reservation
{
  public int Id { get; set; }
  public DateTime StartDate { get; set; }
  public DateTime EndDate { get; set; }
  public RoomType RoomType { get; set; }
  public int RoomId { get; set; }
  public Room Room { get; set; }
  public int VisitorId { get; set; }
  public Visitor Visitor { get; set; }

}

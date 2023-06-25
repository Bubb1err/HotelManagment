namespace HotelManagment.Core.Entities;

public class RoomType
{
  public int Id { get; set; }
  public string Type { get; set; }
  // Relations
  public IReadOnlyCollection<Room> Rooms { get; set; }
}
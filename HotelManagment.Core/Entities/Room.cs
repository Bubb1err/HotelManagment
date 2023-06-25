using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagment.Core.Entities;

public class Room
{
  public int Id { get; set; }
  public int RoomNumber { get; set; } 

  // Relations
  [ForeignKey(nameof(Type))]
  public int TypeId { get; set; }
  public RoomType Type { get; set; }

}

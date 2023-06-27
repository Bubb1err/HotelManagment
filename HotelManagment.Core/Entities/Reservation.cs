using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagment.Core.Entities;

public sealed class Reservation
{
  public int Id { get; set; }
  public DateTime StartDate 
    { 
        get { return StartDate; }
        set
        {
            if (value < DateTime.UtcNow) throw new ArgumentException(nameof(Reservation));
            StartDate = value;
        }
     }
  public DateTime EndDate
    {
        get { return EndDate; }
        set
        {
            if(value <= DateTime.UtcNow) throw new ArgumentException(nameof(Reservation));
            EndDate = value;
        }
    }
    public decimal TotalPrice {
        get { return TotalPrice; }
        set
        {
            if (value< 0) throw new ArgumentException(nameof(Reservation));
            TotalPrice = value;
        }
    }
    public int PeopleCount
    {
        get { return PeopleCount; }
        set
        {
            if (value < 1 ) throw new ArgumentException(nameof(Reservation));
            PeopleCount = value;
        }

    }
    // Relations
    [ForeignKey(nameof(Room))]
  public int RoomId { get; set; }
  public Room Room { get; set; }
    [ForeignKey(nameof(Visitor))]
  public int VisitorId { get; set; }
  public Visitor Visitor { get; set; }
}
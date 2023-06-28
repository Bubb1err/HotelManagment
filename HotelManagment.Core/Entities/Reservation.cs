using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagment.Core.Entities;

public sealed class Reservation
{
  public int Id { get; set; }
  
  private DateTime _startDate;
  private DateTime _endDate;
  private decimal _totalPrice;
  private int _peopleCount;

  public DateTime StartDate
  {
    get => _startDate;
    set
    {
      if (value < DateTime.UtcNow) throw new ArgumentException(nameof(Reservation));
      _startDate = value;
    }
  }

  public DateTime EndDate
  {
    get => _endDate;
    set
    {
      if (value <= DateTime.UtcNow) throw new ArgumentException(nameof(Reservation));
      _endDate = value;
    }
  }

  public decimal TotalPrice
  {
    get => _totalPrice;
    set
    {
      if (value < 0) throw new ArgumentException(nameof(Reservation));
      _totalPrice = value;
    }
  }

  public int PeopleCount
  {
    get => _peopleCount;
    set
    {
      if (value < 1) throw new ArgumentException(nameof(Reservation));
      _peopleCount = value;
    }
  }

  // Relations
  [ForeignKey(nameof(Room))]
  public int RoomId { get; set; }
  public Room Room { get; set; } = null!;

  [ForeignKey(nameof(Visitor))]
  public int VisitorId { get; set; }
  public Visitor Visitor { get; set; } = null!;
}
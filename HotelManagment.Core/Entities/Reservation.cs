using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagment.Core.Entities;

public sealed class Reservation
{
  public int Id { get; set; }
    private DateTime _startDate;
  public DateTime StartDate 
    { 
        get { return _startDate; }
        set
        {
            if (value < DateTime.UtcNow) throw new ArgumentException(nameof(Reservation));
            _startDate = value;
        }
     }
    private DateTime _endDate;
  public DateTime EndDate
    {
        get { return _endDate; }
        set
        {
            if(value <= DateTime.UtcNow) throw new ArgumentException(nameof(Reservation));
            _endDate = value;
        }
   }
    private decimal _totalPrice;
    public decimal TotalPrice {
        get { return _totalPrice; }
        set
        {
            if (value< 0) throw new ArgumentException(nameof(Reservation));
            _totalPrice = value;
        }
    }
    private int _peopleCount;
    public int PeopleCount
    {
        get { return _peopleCount; }
        set
        {
            if (value < 1 ) throw new ArgumentException(nameof(Reservation));
            _peopleCount = value;
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
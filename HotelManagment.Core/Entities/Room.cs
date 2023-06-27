
using HotelManagment.Core.Enums;

namespace HotelManagment.Core.Entities;

public sealed class Room
{
  public int Id { get; set; }
    private int _roomNumber;
  public int RoomNumber
    {
        get { return _roomNumber; }
        set
        {
            if (value < 0) throw new ArithmeticException(nameof(Room));
            _roomNumber = value;
        }
    }
    private int _floor;
    public int Floor
    {
        get { return _floor; }
        set
        {
            if (value < 0) throw new ArithmeticException(nameof(Room));
            _floor = value;
        }
    }
    private int _peopleCapacity;
    public int PeopleCapacity
    {
        get { return _peopleCapacity; }
        set
        {
            if (value < 0) throw new ArithmeticException(nameof(Room));
            _peopleCapacity = value;
        }
    }
    private decimal _pricePerNight;
    public decimal PricePerNight
    {
        get { return _pricePerNight; }
        set
        {
            if (value < 0) throw new ArithmeticException(nameof(Room));
            _pricePerNight = value;
        }
    }
    public RoomType Type { get; set; }
    // Relations

    public IReadOnlyCollection<RoomBenefit> Benefits { get; set; }
    public Room()
    {
        Benefits = new List<RoomBenefit>();
    }

}

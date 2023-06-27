
using HotelManagment.Core.Enums;

namespace HotelManagment.Core.Entities;

public sealed class Room
{
  public int Id { get; set; }
  public int RoomNumber
    {
        get { return RoomNumber; }
        set
        {
            if (value < 0) throw new ArithmeticException(nameof(Room));
            RoomNumber = value;
        }
    }
    public int Floor
    {
        get { return Floor; }
        set
        {
            if (value < 0) throw new ArithmeticException(nameof(Room));
            Floor = value;
        }
    }
    public int PeopleCapacity
    {
        get { return PeopleCapacity; }
        set
        {
            if (value < 0) throw new ArithmeticException(nameof(Room));
            PeopleCapacity = value;
        }
    }
    public decimal PricePerNight
    {
        get { return PricePerNight; }
        set
        {
            if (value < 0) throw new ArithmeticException(nameof(Room));
            PricePerNight = value;
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

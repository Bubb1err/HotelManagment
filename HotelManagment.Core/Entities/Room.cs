using HotelManagment.Core.Enums;

namespace HotelManagment.Core.Entities;

public sealed class Room
{
  public int Id { get; set; }
  public RoomType Type { get; set; }

  private int _floor;
  private int _peopleCapacity;
  private decimal _pricePerNight;
  private int _roomNumber;
  
  public int RoomNumber
  {
    get => _roomNumber;
    set
    {
      if (value < 0) throw new ArithmeticException(nameof(Room));
      _roomNumber = value;
    }
  }

  public int Floor
  {
    get => _floor;
    set
    {
      if (value < 0) throw new ArithmeticException(nameof(Room));
      _floor = value;
    }
  }

  public int PeopleCapacity
  {
    get => _peopleCapacity;
    set
    {
      if (value < 0) throw new ArithmeticException(nameof(Room));
      _peopleCapacity = value;
    }
  }

  public decimal PricePerNight
  {
    get => _pricePerNight;
    set
    {
      if (value < 0) throw new ArithmeticException(nameof(Room));
      _pricePerNight = value;
    }
  }

  
  // Relations
  public IReadOnlyCollection<RoomBenefit> Benefits { get; set; } = null!;
}
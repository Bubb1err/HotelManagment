using HotelManagment.Core.Enums;

namespace HotelManagment.Core.Entities;

public class Visitor
{
  public int Id { get; set; }
  public string FirstName { get; set; }
  public string LastName { get; set; }
  public string Phone { get; set; }
	public Visitor()
	{
		FirstName= string.Empty;
		LastName= string.Empty;
		Phone= string.Empty;
	}
}


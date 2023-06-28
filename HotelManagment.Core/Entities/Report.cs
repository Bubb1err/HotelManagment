using System.ComponentModel.DataAnnotations.Schema;
using HotelManagment.Core.Enums;

namespace HotelManagment.Core.Entities;

public sealed class Report
{
  public int Id { get; set; }
  public string Description { get; set; } = string.Empty;
  public ProblemType ProblemType { get; set; }
  public bool IsSolved { get; set; }
  public DateTime ReportedAt { get; set; } = DateTime.UtcNow;
  public DateTime? EmployeeAcceptTime { get; set; }
  public DateTime? SolvedTime { get; set; }
  
  //Relations
  [ForeignKey(nameof(User))] 
  public string ProblemSolverId { get; set; } = string.Empty;
  public User User { get; set; } = null!;
  
  [ForeignKey(nameof(Room))]
  public int RoomId { get; set; }
  public Room Room { get; set; } = null!;
}

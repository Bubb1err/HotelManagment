using System.ComponentModel.DataAnnotations.Schema;
using HotelManagment.Core.Enums;

namespace HotelManagment.Core.Entities;

public sealed class Report
{
  public int Id { get; set; }
  public string Description { get; set; } 
    public ProblemType ProblemType { get; set; }
    public int RoomId { get; set; }
    public bool IsSolved { get; set; }
    public DateTime? EmployeeAcceptedTime { get; set; }
    public DateTime? SolvedTime { get; set; }
    //Relations
    [ForeignKey(nameof(User))]
    public string ProblemSolverId { get; set; }
    public User User { get; set; }
    public Report()
    {
        Description= string.Empty;
        IsSolved = false;
        ProblemSolverId= string.Empty;
    }
    
}

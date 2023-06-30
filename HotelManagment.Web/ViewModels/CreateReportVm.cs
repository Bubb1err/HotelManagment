using System.ComponentModel.DataAnnotations;
using HotelManagment.Core.Enums;

namespace HotelManagment.Web.ViewModels;

public class CreateReportVm
{
  [Required]
  [MinLength(5)]
  [MaxLength(500)]
  public string Description { get; set; } = string.Empty;
  
  [Required]
  [Range(1, 500)]
  public int RoomId { get; set; }
  
  [Required]
  public ProblemType ProblemType { get; set; }
}
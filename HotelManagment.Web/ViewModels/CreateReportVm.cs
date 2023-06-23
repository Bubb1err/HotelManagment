using System.ComponentModel.DataAnnotations;

namespace HotelManagment.Web.ViewModels;

public class CreateReportVm
{
  [Required, MinLength(5), MaxLength(100)] public string Title { get; set; } = string.Empty;
  [Required, MinLength(5), MaxLength(500)] public string Description { get; set; } = string.Empty;
}
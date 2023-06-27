using System.ComponentModel.DataAnnotations;

namespace HotelManagment.Web.ViewModels;

public class CreateReportVm
{
  [Required, MinLength(5), MaxLength(500)] public string Description { get; set; } = string.Empty;
}
using System.ComponentModel.DataAnnotations;

namespace HotelManagment.Web.ViewModels;

public class RegisterUserVm
{
  [Required]
  public string Username { get; set; } = string.Empty;

  [Required]
  [DataType(DataType.EmailAddress)]
  public string Email { get; set; } = string.Empty;

  [Required]
  [DataType(DataType.Password)]
  public string Password { get; set; } = string.Empty;

  [Required]
  [DataType(DataType.Password)]
  [Compare(nameof(Password))]
  public string ConfirmPassword { get; set; } = string.Empty;
}
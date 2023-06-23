﻿using System.ComponentModel.DataAnnotations;

namespace HotelManagment.Web.ViewModels;

public class LoginUserVm
{
  [Required] public string Username { get; set; } = string.Empty;
  [Required, DataType(DataType.Password)] public string Password { get; set; } = string.Empty;
}
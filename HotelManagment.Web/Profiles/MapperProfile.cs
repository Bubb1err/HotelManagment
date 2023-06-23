using AutoMapper;
using HotelManagment.Core.Entities;
using HotelManagment.Web.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace HotelManagment.Web.Profiles;

public class MapperProfile : Profile
{
  public MapperProfile()
  {
    CreateMap<RegisterUserVm, IdentityUser>();
    CreateMap<RegisterUserVm, User>();
  }
}
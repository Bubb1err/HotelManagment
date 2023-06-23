using AutoMapper;
using HotelManagment.Core.Entities;
using HotelManagment.Web.ViewModels;

namespace HotelManagment.Web.Profiles;

public class MapperProfile : Profile
{
  public MapperProfile()
  {
    CreateMap<LoginUserVm, User>();
  }
}
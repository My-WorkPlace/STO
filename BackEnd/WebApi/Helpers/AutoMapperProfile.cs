using AutoMapper;
using WebApp_JWT.Entities;
using WebApp_JWT.Models.Users;

namespace WebApp_JWT.Helpers
{
  public class AutoMapperProfile : Profile
  {
    public AutoMapperProfile()
    {
      CreateMap<User, UserModel>();
      CreateMap<RegisterModel, User>();
      CreateMap<UpdateModel, User>();
    }
  }
}

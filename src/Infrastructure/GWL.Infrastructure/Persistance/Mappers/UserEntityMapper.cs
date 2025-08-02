using AutoMapper;
using GWL.Domain.Entities;
using GWL.Infrastructure.Persistance.Entities;

namespace GWL.Infrastructure.Persistance.Mappers
{
    public sealed class UserEntityMapper : Profile
    {
        public UserEntityMapper()
        {
            CreateMap<UserEntity, User>();
            CreateMap<User, UserEntity>();
        }
    }
}

using AutoMapper;
using Domain.Dtos.User;
using Domain.Entities;

namespace CrossCutting.Mapping
{
    public class DtoToEntityProfile : Profile
    {
        public DtoToEntityProfile() {
            CreateMap<UserDto, UserEntity>();       
        }
    }
}

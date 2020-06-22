using AutoMapper;
using Domain.Entities;
using Domain.ViewModels.User;

namespace CrossCutting.Mapping
{
    public class EntityToViewModelProfile : Profile
    {
        public EntityToViewModelProfile() { 
            CreateMap<UserEntity, UserDetailViewModel>();
            CreateMap<UserEntity, UserListViewModel>();
        }
    }
}   

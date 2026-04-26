using AutoMapper;
using TaskManagement.Application.DTOs;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<TaskItem, TaskDTO>();
            CreateMap<TaskCreateDTO, TaskItem>();
            CreateMap<TaskUpdateDTO, TaskItem>();
        }
    }
}

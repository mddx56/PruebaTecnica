using AutoMapper;
using PruebaTecnica.Dtos;
using PruebaTecnica.Entities;
namespace PruebaTecnica.Utils

{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Store, StoreDto>();
            CreateMap<MaintenanceTask, MaintenanceTaskDto>();
            CreateMap<MaintenanceTaskCreateDto, MaintenanceTask>();
            CreateMap<User, UserDto>();
        }
    }
}

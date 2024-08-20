using AutoMapper;
using Services.DTO;
using Repositories.Models;

namespace Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employer, EmployerDTO>().ReverseMap();
            CreateMap<Job, JobDTO>().ReverseMap();
            CreateMap<FieldsOfWork, FieldsOfWorkDTO>().ReverseMap();
        }
    }
}

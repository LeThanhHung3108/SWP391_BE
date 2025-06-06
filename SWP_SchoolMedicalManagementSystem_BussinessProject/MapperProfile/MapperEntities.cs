using AutoMapper;
using SWP_SchoolMedicalManagementSystem_API.Models.Requests;
using SWP_SchoolMedicalManagementSystem_BussinessOject.Dto.UserDto;
using SWP_SchoolMedicalManagementSystem_BussinessOject.DTO.Request;
using SWP_SchoolMedicalManagementSystem_BussinessOject.DTO.Response;
using SWP_SchoolMedicalManagementSystem_BussinessOject.Entity;

namespace SWP_SchoolMedicalManagementSystem_BussinessOject.MapperProfile
{
    public class MapperEntities : Profile
    {
        public MapperEntities()
        {
            //User Mapper
            CreateMap<User, UserRegisterRequestDto>().ReverseMap();
            CreateMap<User, UserResponseDto>().ReverseMap();
            CreateMap<User, UserUpdateRequestDto>().ReverseMap();

            CreateMap<Student, StudentRequest>().ReverseMap();
            CreateMap<Student, StudentResponse>().ReverseMap();

            //HealthRecord Mapper
            CreateMap<HealthRecord, HealthRecordRequest>().ReverseMap();
            CreateMap<HealthRecord, HealthRecordResponse>().ReverseMap();
        }
    }
}

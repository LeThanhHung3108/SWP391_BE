using AutoMapper;
using SWP_SchoolMedicalManagementSystem_API.Models.Requests;
using SWP_SchoolMedicalManagementSystem_BussinessOject.Dto.MedicalIncidentDto;
using SWP_SchoolMedicalManagementSystem_BussinessOject.Dto.MedicalSupplierDto;
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
            //Incident Mapper
            CreateMap<MedicalIncident, IncidentResponseDto>().ReverseMap();
            CreateMap<MedicalIncident, IncidentCreateRequestDto>().ReverseMap();
            CreateMap<MedicalIncident, IncidentUpdateRequestDto>().ReverseMap();

            //Medcal Supply Mapper
            CreateMap<MedicalSupplier, SupplierRequestDto>().ReverseMap();
            CreateMap<MedicalSupplier, SupplierResponseDto>().ReverseMap();
        }
    }
}

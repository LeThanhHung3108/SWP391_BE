using AutoMapper;
using SWP_SchoolMedicalManagementSystem_BussinessOject.Dto.HealthCheckupResultDto;
using SWP_SchoolMedicalManagementSystem_BussinessOject.Dto.MedicalConsultationDto;
using SWP_SchoolMedicalManagementSystem_BussinessOject.Dto.MedicalDiaryDto;
using SWP_SchoolMedicalManagementSystem_BussinessOject.Dto.MedicalIncidentDto;
using SWP_SchoolMedicalManagementSystem_BussinessOject.Dto.MedicalSupplierDto;
using SWP_SchoolMedicalManagementSystem_BussinessOject.Dto.MedicalSupplyUsageDto;
using SWP_SchoolMedicalManagementSystem_BussinessOject.Dto.UserDto;
using SWP_SchoolMedicalManagementSystem_BussinessOject.DTO.HealthRecordDto;
using SWP_SchoolMedicalManagementSystem_BussinessOject.DTO.MedicationRequestsDto;
using SWP_SchoolMedicalManagementSystem_BussinessOject.DTO.StudentDto;
using SWP_SchoolMedicalManagementSystem_BussinessOject.DTO.VaccCampaignDto;
using SWP_SchoolMedicalManagementSystem_BussinessOject.DTO.VaccFormDto;
using SWP_SchoolMedicalManagementSystem_BussinessOject.DTO.VaccScheduleDto;
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
            CreateMap<User, UserCreateRequestDto>().ReverseMap();
            CreateMap<User, UserUpdateRequestDto>().ReverseMap();

            //Student Mapper
            CreateMap<Student, StudentRequest>().ReverseMap();
            CreateMap<Student, StudentResponse>().ReverseMap();

            //HealthRecord Mapper
            CreateMap<HealthRecord, HealthRecordRequest>().ReverseMap();
            CreateMap<HealthRecord, HealthRecordResponse>().ReverseMap();

            //Medical Request Mapper
            CreateMap<MedicalRequest, MedicationReqRequest>().ReverseMap();
            CreateMap<MedicalRequest, MedicationReqResponse>()
                .ForMember(dest => dest.StudentCode, opt => opt.MapFrom(x => x.Student!.StudentCode))
                .ForMember(dest => dest.StudentName, opt => opt.MapFrom(src => src.Student!.FullName))
                .ForMember(dest => dest.MedicalStaffId, opt => opt.MapFrom(src => src.MedicalStaffId))
                .ForMember(dest => dest.MedicalStaffName, opt => opt.MapFrom(src => src.MedicalStaff!.FullName))
                .ReverseMap();

            //Vaccination Campaign Mapper
            CreateMap<Campaign, CampaignRequest>()
                     .ForMember(dest => dest.Schedules, opt => opt.MapFrom(src => src.Schedules))
                     .ReverseMap();
            CreateMap<Campaign, CampaignRequest>().ReverseMap();
            CreateMap<Campaign, CampaignResponse>().ReverseMap();

            //Vaccination Schedule Mapper
            CreateMap<Schedule, ScheduleRequest>().ReverseMap();
            CreateMap<Schedule, ScheduleResponse>().ReverseMap();

            //Vaccination Consent Form Mapper
            CreateMap<ConsentForm, ConsentFormRequest>().ReverseMap();
            CreateMap<ConsentForm, ConsentFormResponse>().ReverseMap();

            //Incident Mapper
            CreateMap<MedicalIncident, IncidentResponseDto>()
                .ForMember(dest => dest.MedicalStaffId, opt => opt.MapFrom(src => src.MedicalStaff!.Id))
                .ReverseMap();
            CreateMap<MedicalIncident, IncidentCreateRequestDto>().ReverseMap();
            CreateMap<MedicalIncident, IncidentUpdateRequestDto>().ReverseMap();

            //Medcal Supply Mapper
            CreateMap<MedicalSupply, SupplierRequestDto>().ReverseMap();
            CreateMap<MedicalSupply, SupplierResponseDto>().ReverseMap();

            // Medical Supply Usage Mapper
            CreateMap<MedicalSupplyUsage, MedicalSupplyUsageCreateDto>().ReverseMap();
            CreateMap<MedicalSupplyUsage, MedicalSupplyUsageResponseDto>().ReverseMap();

            // Medical Diary Mapper
            CreateMap<MedicalDiary, MedicalDiaryRequestDto>().ReverseMap();
            CreateMap<MedicalDiary, MedicalDiaryResponseDto>()
                .ForMember(dest => dest.StudentName, opt => opt.MapFrom(src => src.MedicationReq!.Student!.FullName))
                .ReverseMap();

            // HealthCheckup Result Mapper
            CreateMap<HealthCheckupResult, HealthCheckupCreateRequestDto>().ReverseMap();
            CreateMap<HealthCheckupResult, HealthCheckupUpdateRequestDto>().ReverseMap();
            CreateMap<HealthCheckupResult, HealthCheckupResponseDto>().ReverseMap();

            // Medical Consultation Mapper
            CreateMap<MedicalConsultation, MedicalConsultationCreateRequestDto>().ReverseMap();
            CreateMap<MedicalConsultation, MedicalConsultationUpdateRequesteDto>().ReverseMap();
            CreateMap<MedicalConsultation, MedicalConsultationResponeDto>()
                .ForMember(dest => dest.StudentName, opt => opt.MapFrom(src => src.Student!.FullName))
                .ForMember(dest => dest.MedicalStaffName, opt => opt.MapFrom(src => src.MedicalStaff!.FullName))
                .ReverseMap();
        }
    }
}

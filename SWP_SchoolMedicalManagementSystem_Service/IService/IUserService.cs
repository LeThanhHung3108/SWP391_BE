using SWP_SchoolMedicalManagementSystem_BussinessOject.Dto.AuthDto;
using SWP_SchoolMedicalManagementSystem_BussinessOject.Dto.UserDto;
using SWP_SchoolMedicalManagementSystem_BussinessOject.Entity;

namespace SWP_SchoolMedicalManagementSystem_Service.IService
{
    public interface IUserService
    {
        Task<UserResponseDto?> GetUserByIdAsync(Guid userId);
        Task<UserResponseDto?> GetUserByUsernamelAsync(string username);
        Task<List<UserResponseDto>> GetAllUsersAsync();
        Task<AuthResponseDto> Login(AuthRequestDto request);
        Task Register(UserRegisterRequestDto request);
        Task UpdateUserAsync(Guid id, UserUpdateRequestDto request);
        Task DeleteUserAsync(Guid userId);
    }
}

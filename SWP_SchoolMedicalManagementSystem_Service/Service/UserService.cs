using AutoMapper;
using Microsoft.AspNetCore.Http;
using SWP_SchoolMedicalManagementSystem_BussinessOject.Dto.AuthDto;
using SWP_SchoolMedicalManagementSystem_BussinessOject.Dto.UserDto;
using SWP_SchoolMedicalManagementSystem_BussinessOject.Entity;
using SWP_SchoolMedicalManagementSystem_Service.Extension;
using SWP_SchoolMedicalManagementSystem_Service.Repository.Interface;
using SWP_SchoolMedicalManagementSystem_Service.Service.Interface;

namespace SWP_SchoolMedicalManagementSystem_Service.Service
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ITokenGeneratior _tokenGenerator;

        public UserService(IHttpContextAccessor httpContextAccessor, IUserRepository userRepository, IMapper mapper, ITokenGeneratior tokenGeneratior)
        {
            _httpContextAccessor = httpContextAccessor;
            _userRepository = userRepository;
            _mapper = mapper;
            _tokenGenerator = tokenGeneratior;
        }

        public Task DeleteUserAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserResponseDto>> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UserResponseDto?> GetUserByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<UserResponseDto?> GetUserByIdAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public async Task<AuthResponseDto> Login(AuthRequestDto request)
        {
            var user = _userRepository.GetUserByUsernameAsync(request.Username).Result;
            if (user == null || user.Password != request.Password)
            {
                throw new UnauthorizedAccessException("Invalid username or password.");
            }
            return await _tokenGenerator.GenerateToken(user, user.UserRole.ToString());
        }

        public async Task Register(UserRegisterRequestDto request)
        {
            var user = _mapper.Map<User>(request);
            user.UserRole = SchoolMedicalManagementSystem.Enum.UserRole.Parent;
            await _userRepository.AddUserAsync(user);
        }

        public Task UpdateUserAsync(Guid id, UserRegisterRequestDto request)
        {
            throw new NotImplementedException();
        }
    }
}

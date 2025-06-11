using AutoMapper;
using Microsoft.AspNetCore.Http;
using SWP_SchoolMedicalManagementSystem_BussinessOject.Dto.AuthDto;
using SWP_SchoolMedicalManagementSystem_BussinessOject.Dto.UserDto;
using SWP_SchoolMedicalManagementSystem_BussinessOject.Entity;
using SWP_SchoolMedicalManagementSystem_Service.Extension;
using SWP_SchoolMedicalManagementSystem_Service.Service.Interface;
using System.Security.Cryptography;
using System.Text;
using SWP_SchoolMedicalManagementSystem_Service.Repository.Interface;

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

        public async Task DeleteUserAsync(Guid userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            if (user == null)
            {
                throw new KeyNotFoundException("User not found.");
            }
            await _userRepository.DeleteUserAsync(userId);
        }

        public async Task<List<UserResponseDto>> GetAllUsersAsync()
        {
            var listUser = await _userRepository.GetAllUsersAsync();
            if (listUser == null || !listUser.Any())
            {
                throw new KeyNotFoundException("No users found.");
            }
            return _mapper.Map<List<UserResponseDto>>(listUser);
        }

        public async Task<UserResponseDto?> GetUserByIdAsync(Guid userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            if (user == null)
            {
                throw new KeyNotFoundException("User not found.");
            }
            return _mapper.Map<UserResponseDto>(user);
        }

        public async Task<UserResponseDto?> GetUserByUsernamelAsync(string username)
        {
            var user = await _userRepository.GetUserByUsernameAsync(username);
            if (user == null)
            {
                throw new KeyNotFoundException("User not found.");
            }
            return _mapper.Map<UserResponseDto>(user);
        }

        public async Task<AuthResponseDto> Login(AuthRequestDto request)
        {
            var user = await _userRepository.GetUserByUsernameAsync(request.Username);
            if (user == null || user.Password != HashPasswordToSha256(request.Password))
            {
                throw new UnauthorizedAccessException("Invalid username or password.");
            }
            return await _tokenGenerator.GenerateToken(user, user.UserRole.ToString());
        }

        public async Task Register(UserRegisterRequestDto request)
        {
            var existingUser = await _userRepository.GetUserByUsernameAsync(request.Username);
            if (existingUser != null)
            {
                throw new InvalidOperationException("Username already exists.");
            }

            var user = _mapper.Map<User>(request);
            user.Password = HashPasswordToSha256(request.Password);
            user.CreateAt = DateTime.UtcNow;
            user.CreatedBy = "System";
            user.UserRole = SchoolMedicalManagementSystem.Enum.UserRole.Parent;
            await _userRepository.AddUserAsync(user);
        }

        public async Task UpdateUserAsync(Guid id, UserUpdateRequestDto request)
        {
            var oldUser = await _userRepository.GetUserByIdAsync(id);
            if (oldUser == null)
            {
                throw new KeyNotFoundException("User not found.");
            }
            var newUser = _mapper.Map(request, oldUser);
            newUser.Id = id;
            newUser.UpdateAt = DateTime.UtcNow;
            newUser.UpdatedBy = GetCurrentUsername();
            await _userRepository.UpdateUserAsync(newUser);
        }

        private string GetCurrentUsername()
        {
            return _httpContextAccessor.HttpContext?.User.FindFirst("username")?.Value ?? "Unknown User";
        }

        private string HashPasswordToSha256(string password)
        {
            using var sha256 = SHA256.Create();
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            var sb = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                sb.Append(bytes[i].ToString("x2"));
            }
            return sb.ToString();
        }
    }
}

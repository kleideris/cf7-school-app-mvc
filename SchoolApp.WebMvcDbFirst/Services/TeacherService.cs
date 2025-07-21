using AutoMapper;
using SchoolApp.WebMvcDbFirst.Data;
using SchoolApp.WebMvcDbFirst.DTO;
using SchoolApp.WebMvcDbFirst.Repositories;

namespace SchoolApp.WebMvcDbFirst.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public TeacherService(IUnitOfWork unitOfWork, IMapper mapper, ILogger logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<User>> GetAllUsersTeachersAsync()
        {
            List<User> userTeachers = new();
            try
            {
                userTeachers = await _unitOfWork.TeacherRepository.GetAllUsersTeachersAsync();
                _logger.LogInformation("{Message}", "All teachers returned");
            }
            catch (Exception ex)
            {
                _logger.LogError("{Message}{Exception}", ex.Message, ex.StackTrace);
            }
            return userTeachers;
        }

        public Task<List<User>> GetAllUsersTeachersAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetTeacherByUsernameAsync(string username)
        {
            throw new NotImplementedException();
        }

        public Task<int?> GetTeacherCountAsync()
        {
            throw new NotImplementedException();
        }

        public Task SignUpUserAsync(TeacherSignUpDTO request)
        {
            throw new NotImplementedException();
        }
    }
}

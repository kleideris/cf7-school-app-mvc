using AutoMapper;
using SchoolApp.WebMvcDbFirst.Data;
using SchoolApp.WebMvcDbFirst.Repositories;

namespace SchoolApp.WebMvcDbFirst.Services
{
    public class StudentService : IStudentService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<StudentService> _logger;

        public async Task<bool> DeleteStudentAsync(int id)
        {
            bool studentDeleted = false;

            try
            {
                studentDeleted = await _unitOfWork.StudentRepository.DeleteAsync(id);
                _logger.LogInformation("{Message}", "Student with id: " + id + " deleted.");
            }
            catch (Exception ex)
            {
                _logger.LogError("{Message}{Exception}", ex.Message, ex.StackTrace);
                throw;
            }
            return studentDeleted;
        }

        public async Task<IEnumerable<User>> GetAllStudentsAsync()
        {
            List<User> usersStudents = new();

            try
            {
                usersStudents = await _unitOfWork.StudentRepository.GetAllUsersStudentsAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError("{Message}{Exception}", ex.Message, ex.StackTrace);
                throw;
            }
            return usersStudents;
        }

        public async Task<Student?> GetStudentAsync(int id)
        {
            Student? student = null;

            try
            {
                student = await _unitOfWork.StudentRepository.GetAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError("{Message}{Exception}", ex.Message, ex.StackTrace);
                throw;
            }
            return student;
        }

        public async Task<int> GetStudentCountAsync()
        {
            int count;
            try
            {
                count = await _unitOfWork.StudentRepository.GetCountAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError("{Message}{Exception}", ex.Message, ex.StackTrace);
                throw;
            }
            return count;
        }

        public async Task<List<Course>> GetStudentCourseAsync(int id)
        {
            List<Course> courses;

            try
            {
                courses = await _unitOfWork.StudentRepository.GetStudentCoursesAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError("{Message}{Exception}", ex.Message, ex.StackTrace);
                throw;
            }
            return courses;
        }

        //TODO: ICourseService, CourseService
    }
}

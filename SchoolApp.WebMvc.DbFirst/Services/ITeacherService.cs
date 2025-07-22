using SchoolApp.WebMvcDbFirst.Data;
using SchoolApp.WebMvcDbFirst.DTO;

namespace SchoolApp.WebMvcDbFirst.Services
{
    public interface ITeacherService
    {
        Task SignUpUserAsync(TeacherSignUpDTO request);
        Task<List<User>> GetAllUsersTeachersAsync();
        Task<List<User>> GetAllUsersTeachersAsync(int pageNumber, int pageSize);
        Task<int?> GetTeacherCountAsync();
        Task<User?> GetTeacherByUsernameAsync(string username);
    }
}

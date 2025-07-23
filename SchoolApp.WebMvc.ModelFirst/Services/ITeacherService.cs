using SchoolApp.WebMvc.ModelFirst.Data;
using SchoolApp.WebMvc.ModelFirst.DTO;

namespace SchoolApp.WebMvc.ModelFirst.Services
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

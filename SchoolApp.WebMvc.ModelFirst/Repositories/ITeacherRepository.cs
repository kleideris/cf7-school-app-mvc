using SchoolApp.WebMvc.ModelFirst.Data;
using SchoolApp.WebMvc.ModelFirst.Models;

namespace SchoolApp.WebMvc.ModelFirst.Repositories
{
    public interface ITeacherRepository
    {
        Task<List<Course>> GetTeacherCoursesAsync(int id);
        Task<Teacher?> GetByPhoneNumberAsync(string phoneNumber);
        Task<List<User>> GetAllUsersTeachersAsync();
        Task<List<User>> GetAllUsersTeachersPaginatedAsync(int pageNumber, int pageSize);
        Task<User?> GetUserTeacherByUsernameAsync(string username);
        Task<PaginatedResult<User>> GetPaginatedUsersTeachersAsync(int pageNumber, int pageSize);
        Task<PaginatedResult<User>> GetPaginatedUsersTeacherFilteredAsync(int pageNumber, int pageSize,
            List<Func<User, bool>> predicates);
    }
}

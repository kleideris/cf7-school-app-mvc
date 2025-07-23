using SchoolApp.WebMvc.ModelFirst.Data;

namespace SchoolApp.WebMvc.ModelFirst.Repositories
{
    public interface IStudentRepository
    {
        Task<List<Course>> GetStudentCoursesAsync(int id);
        Task<Student?> GetByAm(string? AM);
        Task<List<User>> GetAllUsersStudentsAsync();
    }
}

using SchoolApp.WebMvcDbFirst.Data;

namespace SchoolApp.WebMvcDbFirst.Repositories
{
    public interface IStudentRepository
    {
        Task<List<Course>> GetStudentCoursesAsync(int id);
        Task<Student?> GetByAm(string? AM);
        Task<List<User>> GetAllUsersStudentsAsync();
    }
}

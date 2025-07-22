using SchoolApp.WebMvcDbFirst.Data;

namespace SchoolApp.WebMvcDbFirst.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<User>> GetAllStudentsAsync();
        Task<List<Course>> GetStudentCourseAsync(int id);
        Task<Student?> GetStudentAsync(int id);
        Task<bool> DeleteStudentAsync(int id);
        Task<int> GetStudentCountAsync();
    }
}

using SchoolApp.WebMvc.ModelFirst.Data;

namespace SchoolApp.WebMvc.ModelFirst.Repositories
{
    public interface ICourseRepository
    {
        Task<List<Student>> GetCourseStudentsAsync(int id);
        Task<Teacher?> GetCourseTeacherAsync(int id);
    }
}

using Microsoft.EntityFrameworkCore;
using SchoolApp.WebMvc.ModelFirst.Data;

namespace SchoolApp.WebMvc.ModelFirst.Repositories
{
    public class CourseRepository : BaseRepository<Course>, ICourseRepository
    {
        public CourseRepository(SchoolAppDbContext context) : base(context)
        {
        }

        public async Task<List<Student>> GetCourseStudentsAsync(int id)
        {
            return await context.Courses
                .Where(c => c.Id == id)
                .SelectMany(c => c.Students)
                .ToListAsync();
        }

        public async Task<Teacher?> GetCourseTeacherAsync(int id)
        {
            var course = await context.Courses
                .Where(c => c.Id == id)
                .SingleOrDefaultAsync();
            return course?.Teacher;
        }
    }
}

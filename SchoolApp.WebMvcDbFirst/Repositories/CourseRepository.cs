using Microsoft.EntityFrameworkCore;
using SchoolApp.WebMvcDbFirst.Data;

namespace SchoolApp.WebMvcDbFirst.Repositories
{
    public class CourseRepository : BaseRepository<Course>, ICourseRepository
    {
        public CourseRepository(MvcDbContext context) : base(context)
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
                .Where(c => c.TeacherId == id)
                .SingleOrDefaultAsync();
            return course?.Teacher;
        }
    }
}

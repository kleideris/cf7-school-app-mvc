using Microsoft.EntityFrameworkCore;
using SchoolApp.WebMvcDbFirst.Core.Enums;
using SchoolApp.WebMvcDbFirst.Data;

namespace SchoolApp.WebMvcDbFirst.Repositories
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(MvcDbContext context) : base(context)
        {
        }

        public async Task<Student?> GetByAm(string? am)
        {
            return await context.Students
                .Where(s => s.Am == am)
                .SingleOrDefaultAsync();
        }

        public async Task<List<Course>> GetStudentCoursesAsync(int id)
        {
            return await context.Students
                .Where(s => s.Id == id)
                .SelectMany(s => s.Courses)
                .ToListAsync();
        }

        public async Task<List<User>> GetAllUsersStudentsAsync()
        {
            return await context.Users
                 .Where(u => u.UserRole == UserRole.Student)
                 .Include(u => u.Student)
                 .ToListAsync();
        }
    }
}


using SchoolApp.WebMvcDbFirst.Data;

namespace SchoolApp.WebMvcDbFirst.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MvcDbContext _context;

        public UnitOfWork(MvcDbContext context)
        {
            _context = context;
        }
        
        public TeacherRepository TeacherRepository => new(_context);

        public StudentRepository StudentRepository => new(_context);

        public CourseRepository CourseRepository => new(_context);

        public UserRepository UserRepository => new(_context);

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}

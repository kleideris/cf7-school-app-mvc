namespace SchoolApp.WebMvcDbFirst.Repositories
{
    public interface IUnitOfWork
    {
        // TODO: UserRepository
        TeacherRepository TeacherRepository { get; }
        StudentRepository StudentRepository { get; }
        CourseRepository CourseRepository { get; }

        Task<bool> SaveAsync();
    }
}

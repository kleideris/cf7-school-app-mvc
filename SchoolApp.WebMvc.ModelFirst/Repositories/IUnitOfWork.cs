namespace SchoolApp.WebMvc.ModelFirst.Repositories
{
    public interface IUnitOfWork
    {
        UserRepository UserRepository { get; }
        TeacherRepository TeacherRepository { get; }
        StudentRepository StudentRepository { get; }
        CourseRepository CourseRepository { get; }

        Task<bool> SaveAsync();
    }
}

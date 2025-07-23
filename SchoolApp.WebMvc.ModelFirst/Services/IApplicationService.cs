using SchoolApp.WebMvc.ModelFirst.Services;

namespace SchoolApp.WebMvc.ModelFirst.Services
{
    public interface IApplicationService
    {
        UserService UserService { get; }
        TeacherService TeacherService { get; }
        StudentService StudentService { get; }
        // CourseService CourseService { get; }
    }
}


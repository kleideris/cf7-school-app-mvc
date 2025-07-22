using SchoolApp.WebMvcDbFirst.Services;

namespace SchoolApp.WebMvcDbFirst.Services
{
    public interface IApplicationService
    {
        UserService UserService { get; }
        TeacherService TeacherService { get; }
        StudentService StudentService { get; }
        // CourseService CourseService { get; }
    }
}


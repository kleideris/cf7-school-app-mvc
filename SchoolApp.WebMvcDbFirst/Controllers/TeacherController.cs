using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolApp.WebMvcDbFirst.DTO;
using SchoolApp.WebMvcDbFirst.Models;
using SchoolApp.WebMvcDbFirst.Services;

namespace SchoolApp.WebMvcDbFirst.Controllers
{
    public class TeacherController : Controller
    {
        private readonly IApplicationService _applicationService;
        public List<Error> ErrorArray { get; set; } = new();

        public TeacherController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpGet]
        [Authorize(Roles = "Teacher")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(TeacherSignUpDTO teacherSignUpDTO)
        {
            //if (!ModelState.IsValid)
            //{
            //    foreach (var entry in ModelState.Values)
            //    {
            //        foreach (var error in entry.Errors)
            //        {
            //            ErrorArray.Add(new Error("", error.ErrorMessage, ""));
            //        }
            //    }
            //    return View(teacherSignUpDTO);  //we resend it so in case of an error the other values are preserved.
            //}

            if (!ModelState.IsValid)
            {
                return View(teacherSignUpDTO);
            }

            try
            {
                await _applicationService.TeacherService.SignUpUserAsync(teacherSignUpDTO);
                return RedirectToAction("Login", "User");
            }
            catch (Exception ex)
            {
                ErrorArray.Add(new Error("", ex.Message, ""));
                ViewData["ErrorArray"] = ErrorArray;
                return View();
            }
        }
    }
}

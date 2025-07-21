using SchoolApp.WebMvcDbFirst.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace SchoolApp.WebMvcDbFirst.DTO
{
    public class TeacherSignUpDTO
    {
        [StringLength(50, MinimumLength = 2, ErrorMessage ="Username must be between 2 and 50 characters.")]
        public string? Username { get; set; }

        [StringLength(100, ErrorMessage = "Email must not exceed 100 characters.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string? Email { get; set; }

        [RegularExpression(@"(?=.*?[A-Z])(?=.*[a-z])(?=.*?\d)(?=.*\W)^.{8,}$",
            ErrorMessage ="Password must contain at least one uppercase, one lowercase, one digit and one special character")]
        public string? Password { get; set; }

        [StringLength(50, MinimumLength = 2, ErrorMessage = "Firstname must be between 2 and 50 characters.")]
        public string? Firstname { get; set; }

        [StringLength(50, MinimumLength = 2, ErrorMessage = "Lastname must be between 2 and 50 characters.")]
        public string? Lastname { get; set; }

        [StringLength(15, MinimumLength = 10, ErrorMessage = "Phone number must be at least 10 characters and not exceed 15 characters.")]
        public string? PhoneNumber { get; set; }

        [StringLength(100, MinimumLength = 2, ErrorMessage = "Institution must be between 2 and 100 characters.")]
        public string? Institution { get; set; }

        [EnumDataType(typeof(UserRole), ErrorMessage ="Invalid User role.")]
        public UserRole UserRole { get; set; }
    }
}

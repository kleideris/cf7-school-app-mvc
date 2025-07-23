namespace SchoolApp.WebMvc.ModelFirst.Data
{
    public class Teacher : BaseEntity
    {
        public int Id { get; set; }
        public string Institution { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public int UserId { get; set; } // We dont make this nullable in order for the teacher to get deleted by cascade if we delete the user.

        public virtual User User { get; set; } = null!;
        public virtual ICollection<Course> Courses { get; set; } = new HashSet<Course>();
    }
}

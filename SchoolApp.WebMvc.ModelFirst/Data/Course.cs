namespace SchoolApp.WebMvc.ModelFirst.Data
{
    public class Course
    {
        public int Id { get; set; }
        public string Description { get; set; } = null!;
        public int? TeacherId { get; set; } // We make this nullable so it wont be deleted by cascading if the teacher gets deleted.

        public virtual Teacher? Teacher { get; set; }
        public virtual ICollection<Student> Students { get; set; } = new HashSet<Student>();
    }
}

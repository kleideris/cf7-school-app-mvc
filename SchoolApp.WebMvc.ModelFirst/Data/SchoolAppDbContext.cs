using Microsoft.EntityFrameworkCore;

namespace SchoolApp.WebMvc.ModelFirst.Data
{
    public class SchoolAppDbContext : DbContext
    {
        public SchoolAppDbContext() { }

        public SchoolAppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users");
                //entity.HasKey(e => e.Id);  // this is optional because it is set by default by the conventions if the key its called Id
                entity.Property(e => e.Username).HasMaxLength(255);  // default length is MAX
                entity.Property(e => e.Email).HasMaxLength(255);
                entity.Property(e => e.Password).HasMaxLength(60);
                entity.Property(e => e.Firstname).HasMaxLength(255);
                entity.Property(e => e.Lastname).HasMaxLength(255);
                // all these above could be in comments and it just would set their maxlength
                // to their max (450 chars for indexes since it cant be more than 900 and nvarchar uses two bytes per char).
                entity.Property(e => e.UserRole).HasMaxLength(255).HasConversion<string>(); // HasConversion makes it string to the database

                entity.Property(e => e.InsertedAt)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("GETDATE()");   // this uses the sql servers time as a timestamp?

                entity.Property(e => e.ModifiedAt)
                .ValueGeneratedOnUpdate()
                .HasDefaultValueSql("GETDATE()");

                entity.HasIndex(e => e.Email, "IX_Users_Email").IsUnique();
                entity.HasIndex(e => e.Username, "IX_Users_Username").IsUnique();
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.ToTable("Teachers");
                //entity.Property(e => e.Institution).HasMaxLength(255);
                //entity.Property(e => e.PhoneNumber).HasMaxLength(255);

                entity.Property(e => e.InsertedAt)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("GETDATE()");   // this uses the sql servers time as a timestamp?

                entity.Property(e => e.ModifiedAt)
                .ValueGeneratedOnUpdate()
                .HasDefaultValueSql("GETDATE()");

                entity.HasIndex(e => e.Institution, "IX_Teachers_Institution");
                entity.HasIndex(e => e.PhoneNumber, "IX_Teachers.PhoneNumber").IsUnique();
                entity.HasIndex(e => e.UserId, "IX_Teachers_UserId").IsUnique();    // such an index in 1 to 1 relations is a best practice to optimize queries and ensure uniqueness.

                // Convention on Foreign Key
                //entity.HasOne(d => d.User).WithOne(p => p.Teacher)
                //.HasForeignKey<Teacher>(d => d.UserId)
                //.HasConstraintName("FK_Teachers_Users");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Students");

                entity.Property(e => e.InsertedAt)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("GETDATE()");   // this uses the sql servers time as a timestamp?

                entity.Property(e => e.ModifiedAt)
                .ValueGeneratedOnUpdate()
                .HasDefaultValueSql("GETDATE()");

                entity.Property(e => e.Am).HasMaxLength(10);
                entity.Property(e => e.Institution).HasMaxLength(255);
                entity.Property(e => e.Department).HasMaxLength(255);

                entity.HasIndex(e => e.Institution, "IX_Studentss_Institution");
                entity.HasIndex(e => e.Am, "IX_Students.Am").IsUnique();
                entity.HasIndex(e => e.UserId, "IX_Students_UserId").IsUnique();

                // Convention on Foreign Key
                //entity.HasOne(d => d.User).WithOne(p => p.Teacher)
                //.HasForeignKey<Student>(d => d.UserId)
                //.HasConstraintName("FK_Students_Users");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Courses");
                //entity.Property(e => e.Description).HasMaxLength(255);
                //entity.Property(e => e.TeacherId).HasMaxLength(255);

                entity.HasIndex(e => e.Description, "IX_Courses_Description");

                entity.HasMany(entity => entity.Students).WithMany(s => s.Courses)
                .UsingEntity("StudentsCourses");
            });
        }
    }
}

using Microsoft.EntityFrameworkCore;

namespace ConsoleApplication
{
    public class StudentContext: DbContext
    {
        public StudentContext (DbContextOptions<StudentContext> options)
        : base(options)
        {        
        }
        public DbSet<Student> Students {get; set;}
    }


    public static class StudentsContextFactory
    {
        public static StudentContext Create(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<StudentContext>();
            optionsBuilder.UseSqlite(connectionString); 

            var context = new StudentContext(optionsBuilder.Options);
            context.Database.EnsureCreated();

            return context;
        }
    }


    public class Student
    {
        public Student ()
        {}

        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }
    }
}
using System;
using Microsoft.Extensions.Configuration;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
           var builder = new ConfigurationBuilder()
           .AddJsonFile("appsettings.json", optional : false, reloadOnChange : true);

           var configuration = builder.Build();

           string connectionString = configuration.GetConnectionString("sample");

           var user = new Student() { Name = "Perico", LastName = "Perez" };
           
           using (var context = StudentsContextFactory.Create(connectionString))
           {
               context.Add(user);
               context.SaveChanges();
           }

           Console.WriteLine($"Student was saved in the database with id : {user.Id}");
        }
    }
}

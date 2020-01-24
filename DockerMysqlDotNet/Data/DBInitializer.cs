using DockerMysqlDotNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DockerMysqlDotNet.Data
{
    public class DBInitializer
    {
        public static void init(Context context)
        {
            context.Database.EnsureCreated();
            if (context.Students.Any())
            {
                return;
            }
            var students = new Student[]
            {
                new Student
                {
                    Name = "Niyazi",
                    Surname="Ekinci"
                }
            };

            context.Students.AddRange(students);
            context.SaveChanges();
        }
    }
}

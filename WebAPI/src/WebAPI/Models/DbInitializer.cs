using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using WebAPI.Data;

namespace WebAPI.Models
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DbAppContext(serviceProvider.GetRequiredService<DbContextOptions<DbAppContext>>()))
            {
                context.Database.EnsureCreated();

                if (context.Students.Any())
                {
                    return; // DB has been seeded
                }

                context.Students.Add(new Student { ID = "1", FullName = "A", Class = "12" });
                context.Students.Add(new Student { ID = "2", FullName = "E", Class = "11" });
                context.Students.Add(new Student { ID = "3", FullName = "G", Class = "11" });

                context.SaveChanges();
            }
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ReduxstagramAPI.Data;

namespace ReduxstagramAPI.Models
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider provider)
        {
            using (var context = new DbAppContext(provider.GetRequiredService<DbContextOptions<DbAppContext>>()))
            {
                context.Database.EnsureCreated();

                /*
                if (context.Students.Any())
                {
                    return; // DB has been seeded
                }

                context.Students.Add(new Student { ID = "1", FullName = "A", Class = "12" });
                context.Students.Add(new Student { ID = "2", FullName = "E", Class = "11" });
                context.Students.Add(new Student { ID = "3", FullName = "G", Class = "11" });
                */

                context.SaveChanges();
            }
        }
    }
}

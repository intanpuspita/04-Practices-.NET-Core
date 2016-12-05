using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using EntityFrameworkCore.Data;
using System.Linq;

namespace EntityFrameworkCore.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.Employee.Any())
                {
                    return;
                }

                context.Employee.AddRange(
                    new Employee
                    {
                        FullName = "Annie",
                        DateOfBirth = DateTime.Parse("1993-10-26"),
                        PlaceOfBirth = "Bandung",
                        Address = "Bandung",
                        Email = "annie123@gmail.com",
                        PhoneNumber = "085798754378",
                        Rating = "A"
                    },
                    new Employee
                    {
                        FullName = "Donald",
                        DateOfBirth = DateTime.Parse("1987-10-26"),
                        PlaceOfBirth = "Jakarta",
                        Address = "Jakarta",
                        Email = "donald123@gmail.com",
                        PhoneNumber = "081320765398",
                        Rating = "B"
                    },
                    new Employee
                    {
                        FullName = "Terry",
                        DateOfBirth = DateTime.Parse("1990-10-26"),
                        PlaceOfBirth = "Bogor",
                        Address = "Bogor",
                        Email = "terry123@gmail.com",
                        PhoneNumber = "081547356398",
                        Rating = "C"
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
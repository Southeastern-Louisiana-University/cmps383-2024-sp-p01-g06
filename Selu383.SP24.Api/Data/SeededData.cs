using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Selu383.SP24.Api.Data;
using Selu383.SP24.Api.Entities;
using System;
using System.Linq;
namespace Selu383.SP24.Api.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new DataContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<DataContext>>()))
        {
            // Look for any movies.
            if (context.Hotels.Any())
            {
                return;   // DB has been seeded
            }
            context.Hotels.AddRange(
                new Hotel
                {
                    Name = "Courtyard by Marriott Hammond",
                    Address = "1605 S Magnolia St, Hammond, LA 70403"
                },
                new Hotel
                {
                    Name = "Quality Inn Hammond",
                    Address = "2001 SW Railroad Ave, Hammond, LA 70403"
                }
            );
            context.SaveChanges();
        }
    }
}
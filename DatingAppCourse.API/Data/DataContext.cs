using DatingAppCourse.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace DatingAppCourse.API.Data
{
    public class DataContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<AppUser> Users { get; set; }
    }
}
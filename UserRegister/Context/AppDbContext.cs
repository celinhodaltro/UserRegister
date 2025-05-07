using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using UserRegister.Entities;

namespace UserRegister.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
    }
}
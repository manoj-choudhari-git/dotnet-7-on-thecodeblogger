using Microsoft.EntityFrameworkCore;

using MinimalApiDemo.DataAccess.Entities;

namespace MinimalApiDemo.DataAccess
{
    public class UniversityDbContext : DbContext
    {
        public UniversityDbContext(DbContextOptions<UniversityDbContext> options)
            : base(options)
        {
        }

        public DbSet<StudentEntity> Students { get; set; }
    }
}
using CQRS_Sample.Domain;
using Microsoft.EntityFrameworkCore;

namespace CQRS_Sample.Infraestructure
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<TaskItem> TaskItems { get; set; }
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options
        ) : base(options)
        { }
    }
}

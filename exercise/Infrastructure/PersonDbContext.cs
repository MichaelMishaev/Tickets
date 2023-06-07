using exercise.Domain;
using Microsoft.EntityFrameworkCore;

namespace exercise.Infrastructure
{
    public class PersonDbContext : DbContext
    {
        public DbSet<Person> Orders => Set<Person>();
        public PersonDbContext(DbContextOptions<AgentDBContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PersonDbContext).Assembly);
        }
    }
}

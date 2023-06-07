using exercise.Domain;
using Microsoft.EntityFrameworkCore;

namespace exercise.Infrastructure
{
    public class AgentDBContext:DbContext
    {
        public DbSet<Agent> Orders => Set<Agent>();

        public AgentDBContext(DbContextOptions<AgentDBContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AgentDBContext).Assembly);
        }
    }
}

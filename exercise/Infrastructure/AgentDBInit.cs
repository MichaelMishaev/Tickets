using exercise.Domain.Contracts;
using exercise.Infrastructure.Seeds;
using Microsoft.EntityFrameworkCore;

namespace exercise.Infrastructure
{
    public class AgentDBInit
    {
        private readonly AgentDBContext _agentDBContext;
        public AgentDBInit(AgentDBContext agentDBContext)
        {
            _agentDBContext = agentDBContext;
        }

        public static async Task SeedAsync (IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var initializer = scope.ServiceProvider.GetRequiredService<AgentDBInit>();
                var dateTime = scope.ServiceProvider.GetRequiredService<IDateTime>();

                await initializer._agentDBContext.Database.EnsureDeletedAsync();
                await initializer._agentDBContext.Database.EnsureCreatedAsync();

                await initializer.SeedAgents(dateTime);
            }
        }

        public async Task SeedAgents(IDateTime dateTime)
        {
            if (!await _agentDBContext.Agents.AnyAsync())
            {
                var agents = AgentSeed.GetAgents(dateTime);
                _agentDBContext.Agents.AddRange(agents);
                await _agentDBContext.SaveChangesAsync();
            }
        }

    }
}

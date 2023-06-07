using exercise.Domain;
using exercise.Domain.Contracts;

namespace exercise.Infrastructure.Seeds
{
    public static class AgentSeed
    {
        public static List<Agent> GetAgents(IDateTime datTimeService)
        {
            var agents = new List<Agent>
            {
            GenerateAgent("first","lFirst","1235"),
            GenerateAgent("sec","SecFirst","67891")

        };
            return agents;
        }

        public static Agent GenerateAgent(string name, string lname, string serialNum)
        {
            return new Agent(name, lname, serialNum);
        }
    }
}

using Ardalis.GuardClauses;

namespace exercise.Domain
{
    public class Agent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lname { get; set; }
        public string SerialNumer { get; set; }
        public DateTime DateCreated { get; }
        public AgentType Type { get; set; }

        public Agent(string name, string lname, string serialNumer)
        {
            Guard.Against.NullOrEmpty(name);
            Guard.Against.NullOrEmpty(lname);
            Guard.Against.NullOrEmpty(serialNumer);
            Name = name;
            Lname = lname;
            SerialNumer = serialNumer;
            DateCreated = DateTime.Now;
        }
    }
}

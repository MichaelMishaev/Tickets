using exercise.Domain.Contracts;

namespace exercise.Infrastructure
{
    public class DateTimeProvider : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}

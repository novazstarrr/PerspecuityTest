namespace PerspicuityTest.Database.Models
{
    public class Class
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Name { get; set; } = null!;

        public DateTime Start { get; set; }

        public DateTime End { get; set; }
    }
}

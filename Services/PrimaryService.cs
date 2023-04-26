namespace DependencyInjectionSamples.Services
{
    public class PrimaryService
    {
        public static int CreationCount {get; private set;}
        public Guid Id { get; set; }
        public PrimaryService()
        {
            Id  = Guid.NewGuid();
            CreationCount++;
        }
    }
}
using DependencyInjectionSamples.Services.Interfaces;

namespace DependencyInjectionSamples.Services
{
    public class PrimaryService : IService
    {
        public static int CreationCount {get; private set;}
        private Guid Id { get; set; }
        public PrimaryService()
        {
            Id  = Guid.NewGuid();
            CreationCount++;
        }
        
        public Guid GetGuiId()
        {
            return Id;
        }
    }
}
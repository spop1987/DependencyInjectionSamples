using DependencyInjectionSamples.Services.Interfaces;

namespace DependencyInjectionSamples.Services
{
    public class SecondaryService
    {
        private readonly IService _primaryService;
        public static int CreationCount {get; private set;}
        public Guid Id { get; set; } 
        public SecondaryService(IService primaryService)
        {
            _primaryService = primaryService;
            Id = Guid.NewGuid();
            CreationCount++;
        }

        
        public Guid PrimaryServiceId => _primaryService.GetGuiId();
    }
}
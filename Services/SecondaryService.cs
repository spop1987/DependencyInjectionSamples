namespace DependencyInjectionSamples.Services
{
    public class SecondaryService
    {
        private readonly PrimaryService _primaryService;
        public static int CreationCount {get; private set;}
        public Guid Id { get; set; } 
        public SecondaryService(PrimaryService primaryService)
        {
            _primaryService = primaryService;
            Id = Guid.NewGuid();
            CreationCount++;
        }

        
        public Guid PrimaryServiceId => _primaryService.Id;
    }
}
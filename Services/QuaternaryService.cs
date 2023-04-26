namespace DependencyInjectionSamples.Services
{
    public class QuaternaryService
    {
        private readonly TertiaryService _terciaryService;
        public Guid Id { get; set; } 
        public static int CreationCount {get; private set;}

        public QuaternaryService(TertiaryService tertiaryService)
        {
            _terciaryService = tertiaryService;
            Id = Guid.NewGuid();
            CreationCount++;
        }

        
        public Guid TertiaryServiceId => _terciaryService.Id;
    }
}
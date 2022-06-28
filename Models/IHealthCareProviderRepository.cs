using BlazorWasmPilet.Shared;

namespace BlazorWasmPilet.Server.Models
{
    public interface IHealthCareProviderRepository
    {
        Task<IEnumerable<HealthCareProvider>> GetAllHealthCareProvidersAsync();
        Task<IEnumerable<HealthCareProvider>> Search(string name);

        Task<HealthCareProvider> GetHealthCareProvider(int healthCareProviderId);
        Task<HealthCareProvider> AddHealthCareProvider(HealthCareProvider healthCareProvider);

        Task<HealthCareProvider> UpdateHealthCareProvider(HealthCareProvider healthCareProvider);
        Task DeleteHealthCareProvider(int healthCareProviderId);
    }
}

using BlazorWasmPilet.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorWasmPilet.Server.Models
{
    public class HealthCareProviderRepository : IHealthCareProviderRepository
    {
        private readonly AppDbContext appDbContext;

        public HealthCareProviderRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<HealthCareProvider> AddHealthCareProvider(HealthCareProvider healthCareProvider)
        {
            var result  = await this.appDbContext.healthCareProviders.AddAsync(healthCareProvider);

            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteHealthCareProvider(int healthCareProviderId)
        {
            var result = await this.appDbContext.healthCareProviders
                .FirstOrDefaultAsync(p => p.ProviderId == healthCareProviderId);

            if(result != null)
            {
                appDbContext.healthCareProviders.Remove(result);
                await appDbContext.SaveChangesAsync();

            }  
        }

        public async Task<IEnumerable<HealthCareProvider>> GetAllHealthCareProvidersAsync()
        {
            return await this.appDbContext.healthCareProviders.ToListAsync();
        }

        public async Task<HealthCareProvider> GetHealthCareProvider(int healthCareProviderId)
        {
            var result =  await this.appDbContext.healthCareProviders.FirstOrDefaultAsync(p => p.ProviderId == healthCareProviderId);

            return result;
            
        }

        public async Task<IEnumerable<HealthCareProvider>> Search(string name)
        {
            IQueryable<HealthCareProvider> query = appDbContext.healthCareProviders;

            if(!string.IsNullOrEmpty(name))
            {
                query = query.Where(p => p.Name.Contains(name));
            }
            return await query.ToListAsync();
        }

        public async Task<HealthCareProvider> UpdateHealthCareProvider(HealthCareProvider healthCareProvider)
        {
            var result = await this.appDbContext.healthCareProviders.FirstOrDefaultAsync(e => e.ProviderId == healthCareProvider.ProviderId);   

            if(result != null)
            {
                result.Description = healthCareProvider.Description;    
                result.Name = healthCareProvider.Name;
                result.PhoneNumber = healthCareProvider.PhoneNumber;
                result.location = healthCareProvider.location;

                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}

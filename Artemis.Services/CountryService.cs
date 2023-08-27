using Artemis.Contracts.Entities;
using Artemis.Contracts.Repositories;

namespace Artemis.Services
{
    public class CountryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public async Task CreateCountryAsync(Country country)
        {
            await _unitOfWork.Countries.Create(country);
            _unitOfWork.SaveChangesAsync();
        }

        public async Task<Country?> GetByIdAsync(string id)
            => await _unitOfWork.Countries.GetAsync(id);

        public async Task<List<Country>> GetByCityNameAsync(string city)
            => await _unitOfWork.Countries.GetByCityNameAsync(city);

        public async Task<List<Country>> GetByPartialNameMatchAsync(string name)
            => await _unitOfWork.Countries.GetByPartialNameMatchAsync(name);

        public async Task<Country?> GetByExactNameMatchAsync(string name)
            => await _unitOfWork.Countries.GetByExactNameMatchAsync(name);

        public async Task UpdateCountryAsync(Country country)
        {
            await _unitOfWork.Countries.Update(country);
            _unitOfWork.SaveChangesAsync();
        }

        public CountryService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
    }
}

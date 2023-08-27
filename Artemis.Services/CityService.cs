using Artemis.Contracts.Entities;
using Artemis.Contracts.Repositories;

namespace Artemis.Services
{
    public class CityService
    {
        private readonly IUnitOfWork _unitOfWork;

        public async Task CreateCityAsync(City city)
        {
            await _unitOfWork.Cities.Create(city);
            _unitOfWork.SaveChangesAsync();
        }

        public async Task<City?> GetByIdAsync(string id)
            => await _unitOfWork.Cities.GetAsync(id);

        public async Task<List<City>> GetByCountryNameAsync(string country)
            => await _unitOfWork.Cities.GetByCountryNameAsync(country);

        public async Task<List<City>> GetByPartialNameMatchAsync(string name)
            => await _unitOfWork.Cities.GetByPartialNameMatchAsync(name);

        public async Task<City?> GetByExactNameMatchAsync(string name)
            => await _unitOfWork.Cities.GetByExactNameMatchAsync(name);

        public async Task UpdateCityAsync(City city)
        {
            await _unitOfWork.Cities.Update(city);
            _unitOfWork.SaveChangesAsync();
        }

        public CityService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
    }
}

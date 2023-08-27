using Artemis.Contracts.Entities;
using Artemis.Contracts.Repositories;

namespace Artemis.Services
{
    public class LocationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public async Task CreateLocationAsync(Location location)
        {
            await _unitOfWork.Locations.Create(location);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<Location?> GetByIdAsync(string id)
            => await _unitOfWork.Locations.GetAsync(id);

        public async Task<List<Location>> GetByCityNameAsync(string city)
            => await _unitOfWork.Locations.GetByCityNameAsync(city);

        public async Task<List<Location>> GetByCountryNameAsync(string country)
            => await _unitOfWork.Locations.GetByCountryNameAsync(country);

        public async Task<List<Location>> GetByPartialNameMatchAsync(string name)
            => await _unitOfWork.Locations.GetByPartialNameMatchAsync(name);

        public async Task<Location?> GetByExactNameMatchAsync(string name)
            => await _unitOfWork.Locations.GetByExactNameMatchAsync(name);

        public async Task UpdateLocationAsync(Location location)
        {
            await _unitOfWork.Locations.Update(location);
            await _unitOfWork.SaveChangesAsync();
        }

        public LocationService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
    }
}

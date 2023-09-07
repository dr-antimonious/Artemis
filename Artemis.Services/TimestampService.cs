using Artemis.Contracts.Entities;
using Artemis.Contracts.Repositories;

namespace Artemis.Services
{
    public class TimestampService
    {
        private readonly IUnitOfWork _unitOfWork;

        public async Task CreateTimestampAsync(Timestamp timestamp)
        {
            await _unitOfWork.Timestamps.Create(timestamp);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<Timestamp?> GetByIdAsync(string id)
            => await _unitOfWork.Timestamps.GetAsync(id);

        public async Task<Timestamp?> GetByTimestampAsync(DateTime timestamp)
            => await _unitOfWork.Timestamps.GetByTimestamp(timestamp);

        public async Task UpdateTimestampAsync(Timestamp timestamp)
        {
            await _unitOfWork.Timestamps.Update(timestamp);
            await _unitOfWork.SaveChangesAsync();
        }

        public TimestampService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
    }
}

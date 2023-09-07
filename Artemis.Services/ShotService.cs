using Artemis.Contracts.Entities;
using Artemis.Contracts.Repositories;

namespace Artemis.Services
{
    public class ShotService
    {
        private readonly IUnitOfWork _unitOfWork;

        public async Task CreateShotAsync(Shot shot)
            => await _unitOfWork.Shots.Create(shot);

        public async Task CreateShotsAsync(List<Shot> shots)
            => await _unitOfWork.Shots.CreateMulti(shots);

        public async Task DeleteShotAsync(Shot shot)
        {
            await _unitOfWork.Shots.Delete(shot);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<Shot?> GetByIdAsync(string id)
            => await _unitOfWork.Shots.GetAsync(id);

        public async Task<List<Shot>> GetMultiAsync(List<string> ids)
            => await _unitOfWork.Shots.GetMulti(ids);

        public async Task UpdateShotAsync(Shot shot)
            => await _unitOfWork.Shots.Update(shot);

        public async Task UpdateShotsAsync(List<Shot> shots)
            => await _unitOfWork.Shots.UpdateMulti(shots);

        public ShotService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
    }
}

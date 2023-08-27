using Artemis.Contracts.Entities;
using Artemis.Contracts.Repositories;

namespace Artemis.Services
{
    public class ShotService
    {
        private readonly IUnitOfWork _unitOfWork;

        private async Task CreateShotAsync(Shot shot)
            => await _unitOfWork.Shots.Create(shot);

        public async Task CreateShotsAsync(List<Shot> shots)
            => await Task.Run(() =>
            {
                shots.ForEach(async x => await CreateShotAsync(x));
            });

        public async Task DeleteShotAsync(Shot shot)
        {
            await _unitOfWork.Shots.Delete(shot);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<Shot?> GetByIdAsync(string id)
            => await _unitOfWork.Shots.GetAsync(id);

        public async Task UpdateShotAsync(Shot shot)
            => await _unitOfWork.Shots.Update(shot);

        public async Task UpdateShotsAsync(List<Shot> shots)
            => await Task.Run(() =>
            {
                shots.ForEach(async x => await UpdateShotAsync(x));
            });

        public ShotService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
    }
}

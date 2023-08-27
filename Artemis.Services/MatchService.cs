using Artemis.Contracts.Entities.Matches;
using Artemis.Contracts.Repositories;

namespace Artemis.Services
{
    public class MatchService
    {
        private readonly IUnitOfWork _unitOfWork;

        public async Task CreateMatchAsync(Match match)
        {
            await _unitOfWork.Matches.Create(match);
            await _unitOfWork.SaveChangesAsync();
        }

        private async Task DeleteMatchAsync(Match match)
            => await _unitOfWork.Matches.Delete(match);

        public async Task DeleteSingleAsync(Match match)
        {
            await DeleteMatchAsync(match);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteMultipleAsync(List<Match> matches)
        {
            await Task.Run(() =>
            {
                matches.ForEach(async x => await DeleteMatchAsync(x));
            });

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<Match?> GetByIdAsync(string id)
            => await _unitOfWork.Matches.GetAsync(id);

        public async Task<List<Match?>> GetMultipleByIdAsync(List<string> ids)
        {
            List<Match?> matches = new();

            await Task.Run(() =>
            {
                ids.ForEach(x => matches.Add(GetByIdAsync(x).Result));
            });

            return matches;
        }

        public async Task<List<Match>> GetByUserIdAsync(string userId)
            => await _unitOfWork.Matches.GetByUserIdAsync(userId);

        public async Task UpdateMatchAsync(Match match)
        {
            await _unitOfWork.Matches.Update(match);
            await _unitOfWork.SaveChangesAsync();
        }

        public MatchService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
    }
}

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
            _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteSingleAsync(Match match)
        {
            await _unitOfWork.Matches.Delete(match);
            _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteMultipleAsync(List<Match> matches)
        {
            await _unitOfWork.Matches.DeleteMulti(matches);
            _unitOfWork.SaveChangesAsync();
        }

        public async Task<Match?> GetByIdAsync(string id)
            => await _unitOfWork.Matches.GetAsync(id);

        public async Task<List<Match>> GetMultipleByIdAsync(List<string> ids)
            => await _unitOfWork.Matches.GetMulti(ids);

        public async Task<List<Match>> GetByUserIdAsync(string userId)
            => await _unitOfWork.Matches.GetByUserIdAsync(userId);

        public async Task UpdateMatchAsync(Match match)
        {
            await _unitOfWork.Matches.Update(match);
            _unitOfWork.SaveChangesAsync();
        }

        public MatchService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
    }
}

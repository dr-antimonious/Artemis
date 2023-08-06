namespace Artemis.Contracts.Repositories
{
    public interface IMatchRepository<T> : IRemovableRepository<T> where T : class
    {
        Task<List<T>> GetByUserIdAsync(string userId);
    }
}

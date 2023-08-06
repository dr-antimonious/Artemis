namespace Artemis.Contracts.Repositories
{
    public interface INameRepository<T> : IRepository<T> where T : class
    {
        Task<List<T>> GetByNameAsync(string name);
    }
}

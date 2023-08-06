namespace Artemis.Contracts.Repositories
{
    public interface ILocationRepository<T> : INameRepository<T> where T : class
    {
        Task<List<T>> GetByCityAsync(string city);

        Task<List<T>> GetByCountryAsync(string country);
    }
}

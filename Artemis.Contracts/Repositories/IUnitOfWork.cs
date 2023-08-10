using Artemis.Contracts.Entities;
using Artemis.Contracts.Entities.Interfaces;

namespace Artemis.Contracts.Repositories
{
    public interface IUnitOfWork
    {
        ICityRepository<City> Cities { get; }

        ICountryRepository<Country> Countries { get; }

        ILocationRepository<Location> Locations { get; }

        IMatchRepository<IMatch> Matches { get; }

        IRemovableRepository<IShot> Shots { get; }

        ITimestampRepository<Timestamp> Timestamps { get; }

        IUserRepository<User> Users { get; }

        Task SaveChangesAsync();
    }
}

using Artemis.Contracts.Entities;
using Artemis.Contracts.Entities.Interfaces;

namespace Artemis.Contracts.Repositories
{
    public interface IUnitOfWork
    {
        INameRepository<City> Cities { get; }

        INameRepository<Country> Countries { get; }

        ILocationRepository<Location> Locations { get; }

        IMatchRepository<IMatch> Matches { get; }

        IRemovableRepository<IShot> Shots { get; }

        IRepository<Timestamp> Timestamps { get; }

        IUserRepository<User> Users { get; }
    }
}

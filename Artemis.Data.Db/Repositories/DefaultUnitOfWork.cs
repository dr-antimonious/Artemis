using Artemis.Contracts.Entities;
using Artemis.Contracts.Entities.Matches;
using Artemis.Contracts.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Artemis.Data.Db.Repositories
{
    public class DefaultUnitOfWork : IUnitOfWork
    {
        private ICityRepository<City> _cityRepository = null!;

        private ICountryRepository<Country> _countryRepository = null!;

        private ILocationRepository<Location> _locationRepository = null!;

        private IMatchRepository<Match> _matchRepository = null!;

        private IRemovableRepository<Shot> _shotRepository = null!;

        private ITimestampRepository<Timestamp> _timestampRepository = null!;

        private IUserRepository<User> _userRepository = null!;

        private readonly IdentityDbContext<User, IdentityRole<string>, string> _dbContext;

        public ICityRepository<City> Cities
        {
            get
            {
                _cityRepository ??= new CityRepository(_dbContext);
                return _cityRepository;
            }
        }

        public ICountryRepository<Country> Countries
        {
            get
            {
                _countryRepository ??= new CountryRepository(_dbContext);
                return _countryRepository;
            }
        }

        public ILocationRepository<Location> Locations
        {
            get
            {
                _locationRepository ??= new LocationRepository(_dbContext);
                return _locationRepository;
            }
        }

        public IMatchRepository<Match> Matches
        {
            get
            {
                _matchRepository ??= new MatchRepository(_dbContext);
                return _matchRepository;
            }
        }

        public IRemovableRepository<Shot> Shots
        {
            get
            {
                _shotRepository ??= new ShotRepository(_dbContext);
                return _shotRepository;
            }
        }

        public ITimestampRepository<Timestamp> Timestamps
        {
            get
            {
                _timestampRepository ??= new TimestampRepository(_dbContext);
                return _timestampRepository;
            }
        }

        public IUserRepository<User> Users
        {
            get
            {
                _userRepository ??= new UserRepository(_dbContext);
                return _userRepository;
            }
        }

        public async Task SaveChangesAsync()
        {
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e) when (e is DbUpdateException ||
                                      e is DbUpdateConcurrencyException ||
                                      e is OperationCanceledException)
            {
                Console.WriteLine(e);
            }
        }

        public DefaultUnitOfWork(IdentityDbContext<User, IdentityRole<string>, string> dbContext)
        {
            this._dbContext = dbContext;
        }
    }
}

﻿using Artemis.Contracts.Entities;
using Artemis.Contracts.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Artemis.Data.Db.Repositories
{
    public class LocationRepository : Repository<Location>, ILocationRepository<Location>
    {
        private readonly DbSet<Location> _locations;

        public async Task Create(Location entity)
            => await HandleCancelTask(_locations.AddAsync(entity));

        public async Task<List<Location>> GetAllAsync()
            => await HandleNullCancelTask(_locations
                .Include(x => x.City)
                .Include(x => x.Country)
                .ToListAsync());

        public async Task<Location?> GetAsync(string id)
            => await _locations
                .Include(x => x.City)
                .Include(x => x.Country)
                .FirstOrDefaultAsync(x => x.Id.Equals(id));

        public async Task<List<Location>> GetByCityNameAsync(string city)
            => await HandleNullCancelTask(_locations
                .Include(x => x.City)
                .Include(x => x.Country)
                .Where(x => x.City.Name.Equals(city))
                .ToListAsync());

        public async Task<List<Location>> GetByCountryNameAsync(string country)
            => await HandleNullCancelTask(_locations
                .Include(x => x.City)
                .Include(x => x.Country)
                .Where(x => x.Country.Name.Equals(country))
                .ToListAsync());

        public async Task<List<Location>> GetByPartialNameMatchAsync(string name)
            => await HandleNullCancelTask(_locations
                .Include(x => x.City)
                .Include(x => x.Country)
                .Where(x => x.Name.Contains(name))
                .ToListAsync());

        public async Task<Location?> GetByExactNameMatchAsync(string name)
            => await HandleNullCancelTask(_locations
                .Include(x => x.City)
                .Include(x => x.Country)
                .FirstOrDefaultAsync(x => x.Name.Equals(name)));

        public async Task Update(Location entity)
            => await Task.Run(() => _locations.Update(entity));

        public LocationRepository(IdentityDbContext<User, IdentityRole<string>, string> dbContext)
            => _locations = dbContext.Set<Location>();
    }
}

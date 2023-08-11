﻿using System.ComponentModel.DataAnnotations;

namespace Artemis.Contracts.Entities
{
    public class Location
    {
        [Key]
        public string Id { get; set; }

        public string Name { get; set; } = null!;

        public City City { get; set; } = null!;

        public Country Country { get; set; } = null!;

        public Location()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public Location(string name, City city, Country country)
            : this()
        {
            this.Name = name;
            this.City = city;
            this.Country = country;
        }

        public Location(
            string id,
            string name,
            City city,
            Country country)
        {
            this.Id = id;
            this.Name = name;
            this.City = city;
            this.Country = country;
        }
    }
}

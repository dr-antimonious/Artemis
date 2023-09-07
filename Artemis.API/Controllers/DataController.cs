using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using Artemis.Contracts;
using Artemis.Contracts.DTOs;
using Artemis.Contracts.Entities;
using Artemis.Contracts.Entities.Matches;
using Artemis.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Artemis.API.Controllers
{
    [Authorize, ApiController, Route("artemis/data")]
    public class DataController : ControllerBase
    {
        private readonly CityService _cityService;

        private readonly CountryService _countryService;

        private readonly LocationService _locationService;

        private readonly MatchService _matchService;

        private readonly ShotService _shotService;

        private readonly TimestampService _timestampService;

        private readonly UserService _userService;

        // City service routes

        [HttpPost, Route("city/add"),
        ProducesResponseType(StatusCodes.Status400BadRequest),
        ProducesResponseType(StatusCodes.Status409Conflict),
        ProducesResponseType(StatusCodes.Status201Created),
        ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateCity(
            [FromBody] CityCreateRequestDto createRequest)
        {
            ModelState.ClearValidationState(nameof(createRequest));

            if (TryValidateModel(createRequest, nameof(createRequest)))
            {
                City? city = await _cityService.GetByExactNameMatchAsync(createRequest.Name);

                Country? country = await _countryService.GetByIdAsync(createRequest.Id);

                if (country is null)
                {
                    return BadRequest(createRequest.Id);
                }

                if (city is not null)
                {
                    if (city.Countries.Contains(country))
                    {
                        return Conflict(city);
                    }

                    city.Countries.Add(country);

                    await _cityService.UpdateCityAsync(city);
                    
                    return CreatedAtAction(
                        nameof(GetCityById),
                        new{id = city.Id},
                        city);
                }

                city = new(createRequest.Name);
                country.Cities.Add(city);
                city.Countries.Add(country);

                await _cityService.CreateCityAsync(city);

                return CreatedAtAction(
                    nameof(GetCityById),
                    new {id = city.Id},
                    city);
            }

            return ValidationProblem(ModelState);
        }

        [HttpGet, Route("city/get/by-id"),
         ProducesResponseType(StatusCodes.Status404NotFound),
         ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCityById([FromQuery] string id)
        {
            City? city = await _cityService.GetByIdAsync(id);

            return city is null ? NotFound(id) : Ok(city);
        }

        [HttpGet, Route("city/get/by-country"),
        ProducesResponseType(StatusCodes.Status404NotFound),
        ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCityByCountry([FromQuery] string country)
        {
            List<City> cities = await _cityService.GetByCountryNameAsync(country);

            return cities.IsNullOrEmpty() ? NotFound(country) : Ok(cities);
        }

        [HttpGet, Route("city/get/by-partial"),
         ProducesResponseType(StatusCodes.Status404NotFound),
         ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCityByPartialMatch([FromQuery] string partialName)
        {
            List<City> cities = await _cityService.GetByPartialNameMatchAsync(partialName);

            return cities.IsNullOrEmpty() ? NotFound(partialName) : Ok(cities);
        }

        [HttpGet, Route("city/get/by-exact"),
         ProducesResponseType(StatusCodes.Status404NotFound),
         ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCityByExactMatch([FromQuery] string name)
        {
            City? city = await _cityService.GetByExactNameMatchAsync(name);

            return city is null ? NotFound(name) : Ok(city);
        }

        // Country service routes

        [HttpPost, Route("country/add"),
         ProducesResponseType(StatusCodes.Status409Conflict),
         ProducesResponseType(StatusCodes.Status201Created),
         ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateCountry(
            [FromBody, Required(ErrorMessage = "Country name is required")]
            string name)
        {
            ModelState.ClearValidationState(nameof(name));

            if (TryValidateModel(name, nameof(name)))
            {
                if ((await _countryService.GetByExactNameMatchAsync(name))
                    is not null) 
                    return Conflict(await _countryService.GetByExactNameMatchAsync(name));

                Country country = new(name);

                await _countryService.CreateCountryAsync(country);

                return CreatedAtAction(
                    nameof(GetCountryById),
                    new {id = country.Id},
                    country);
            }

            return ValidationProblem(ModelState);
        }

        [HttpGet, Route("country/get/by-id"),
         ProducesResponseType(StatusCodes.Status404NotFound),
         ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCountryById([FromQuery] string id)
        {
            Country? country = await _countryService.GetByIdAsync(id);

            return country is null ? NotFound(id) : Ok(country);
        }

        [HttpGet, Route("country/get/by-city"),
         ProducesResponseType(StatusCodes.Status404NotFound),
         ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCountryByCity([FromQuery] string city)
        {
            List<Country> countries = await _countryService.GetByCityNameAsync(city);

            return countries.IsNullOrEmpty() ? NotFound(city) : Ok(countries);
        }

        [HttpGet, Route("country/get/by-partial"),
         ProducesResponseType(StatusCodes.Status404NotFound),
         ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCountryByPartial([FromQuery] string partialName)
        {
            List<Country> countries = await _countryService.GetByPartialNameMatchAsync(partialName);

            return countries.IsNullOrEmpty() ? NotFound(partialName) : Ok(countries);
        }

        [HttpGet, Route("country/get/by-exact"),
         ProducesResponseType(StatusCodes.Status404NotFound),
         ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCountryByExact([FromQuery] string name)
        {
            Country? country = await _countryService.GetByExactNameMatchAsync(name);

            return country is null ? NotFound(name) : Ok(country);
        }

        // Location service routes

        [HttpPost, Route("location/add"),
         ProducesResponseType(StatusCodes.Status409Conflict),
         ProducesResponseType(StatusCodes.Status400BadRequest),
         ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateLocation(
            [FromBody] LocationCreateRequestDto createRequest)
        {
            ModelState.ClearValidationState(nameof(createRequest));

            if (TryValidateModel(createRequest, nameof(createRequest)))
            {
                Location? location = await _locationService.GetByExactNameMatchAsync(createRequest.Name);

                if (location is not null)
                {
                    return Conflict(location);
                }

                City? city = await _cityService.GetByIdAsync(createRequest.CityId);

                if (city is null)
                {
                    return BadRequest(createRequest.CityId);
                }

                Country? country = await _countryService.GetByIdAsync(createRequest.CountryId);

                if (country is null)
                {
                    return BadRequest(createRequest.CountryId);
                }

                location = new();
                location.Name = createRequest.Name;
                location.Country = country;
                location.City = city;

                await _locationService.CreateLocationAsync(location);

                return CreatedAtAction(
                    nameof(GetLocationById),
                    new {id = location.Id},
                    location);
            }

            return ValidationProblem(ModelState);
        }

        [HttpGet, Route("location/get/by-id"),
         ProducesResponseType(StatusCodes.Status404NotFound),
         ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetLocationById([FromQuery] string id)
        {
            Location? location = await _locationService.GetByIdAsync(id);

            return location is null ? NotFound(id) : Ok(location);
        }

        [HttpGet, Route("location/get/by-city"),
         ProducesResponseType(StatusCodes.Status404NotFound),
         ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetLocationByCity([FromQuery] string city)
        {
            List<Location> locations = await _locationService.GetByCityNameAsync(city);

            return locations.IsNullOrEmpty() ? NotFound(city) : Ok(locations);
        }

        [HttpGet, Route("location/get/by-country"),
         ProducesResponseType(StatusCodes.Status404NotFound),
         ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetLocationByCountry([FromQuery] string country)
        {
            List<Location> locations = await _locationService.GetByCountryNameAsync(country);

            return locations.IsNullOrEmpty() ? NotFound(country) : Ok(locations);
        }

        [HttpGet, Route("location/get/by-partial"),
         ProducesResponseType(StatusCodes.Status404NotFound),
         ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetLocationByPartial([FromQuery] string partialName)
        {
            List<Location> locations = await _locationService.GetByPartialNameMatchAsync(partialName);

            return locations.IsNullOrEmpty() ? NotFound(partialName) : Ok(locations);
        }

        [HttpGet, Route("location/get/by-exact"),
         ProducesResponseType(StatusCodes.Status404NotFound),
         ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetLocationByExact([FromQuery] string name)
        {
            Location? location = await _locationService.GetByExactNameMatchAsync(name);

            return location is null ? NotFound(name) : Ok(location);
        }

        // Timestamp service routes

        [HttpPost, Route("timestamp/add"),
         ProducesResponseType(StatusCodes.Status409Conflict),
         ProducesResponseType(StatusCodes.Status201Created),
         ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateTimestamp(
            [FromBody, Required(ErrorMessage = "Timestamp is required")]
            DateTime timestamp)
        {
            ModelState.ClearValidationState(nameof(timestamp));

            if (TryValidateModel(timestamp, nameof(timestamp)))
            {
                Timestamp? timeStamp = await _timestampService.GetByTimestampAsync(timestamp);

                if (timeStamp is not null)
                {
                    return Conflict(timeStamp);
                }

                timeStamp = new(timestamp);

                await _timestampService.CreateTimestampAsync(timeStamp);

                return CreatedAtAction(
                    nameof(GetTimestampById),
                    new {id = timeStamp.Id},
                    timeStamp);
            }

            return ValidationProblem(ModelState);
        }

        [HttpGet, Route("timestamp/get/by-id"),
         ProducesResponseType(StatusCodes.Status404NotFound),
         ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetTimestampById([FromQuery] string id)
        {
            Timestamp? timestamp = await _timestampService.GetByIdAsync(id);

            return timestamp is null ? NotFound(id) : Ok(timestamp);
        }

        [HttpGet, Route("timestamp/get/by-timestamp"),
         ProducesResponseType(StatusCodes.Status404NotFound),
         ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetTimestampByTimestamp([FromBody] DateTime timestamp)
        {
            Timestamp? timeStamp = await _timestampService.GetByTimestampAsync(timestamp);

            return timeStamp is null ? NotFound(timestamp) : Ok(timeStamp);
        }

        // Match service routes

        [HttpPost, Route("match/add"),
         ProducesResponseType(StatusCodes.Status201Created),
         ProducesResponseType(StatusCodes.Status400BadRequest),
         ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> CreateMatch(
            [FromBody] MatchCreateRequestDto createRequest
        )
        {
            ModelState.ClearValidationState(nameof(createRequest));

            if (TryValidateModel(createRequest, nameof(createRequest)))
            {
                if (createRequest.ShooterId.Equals(User.FindFirstValue(ClaimTypes.NameIdentifier)))
                {
                    if (Match.TotalShots.TryGetValue(createRequest.Type, out int expectedShotTotal))
                    {
                        if (createRequest.Shots.Count.Equals(expectedShotTotal))
                        {
                            if (Match.CreateMatch.TryGetValue(createRequest.Type, out Func<MatchCreateRequestDto, Match>? creator))
                            {

                                Match match = creator(createRequest);

                                List<Shot> shots = match.Shots;

                                foreach (Shot shot in match.Shots)
                                {

                                    if (shot.TimeStamp is not null)
                                    {

                                        shot.TimeStamp = await _timestampService.GetByIdAsync(shot.TimeStamp.Id);

                                    }
                                }

                                await _shotService.CreateShotsAsync(shots);

                                Timestamp startTimestamp = await _timestampService
                                    .GetByIdAsync(createRequest.StartTimestampId);

                                Timestamp endTimestamp = await _timestampService
                                    .GetByIdAsync(createRequest.EndTimestampId);

                                Location location =
                                    await _locationService.GetByIdAsync(createRequest.LocationId);

                                User shooter = await _userService.GetByIdAsync(createRequest.ShooterId);

                                match.StartTimestamp = startTimestamp;

                                match.EndTimestamp = endTimestamp;

                                match.Location = location;

                                match.Shooter = shooter;


                                await _matchService.CreateMatchAsync(match);

                                return CreatedAtAction(
                                    nameof(GetMatchById),
                                    new { id = match.Id },
                                    match.CreateDto());
                            }

                            return BadRequest(createRequest.Type);
                        }

                        return BadRequest(createRequest.Shots.Count);
                    }

                    return BadRequest(createRequest.Type);
                }

                return Unauthorized();
            }

            return ValidationProblem(ModelState);
        }

        [HttpGet, Route("match/get/by-id"),
         ProducesResponseType(StatusCodes.Status404NotFound),
         ProducesResponseType(StatusCodes.Status401Unauthorized),
         ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetMatchById([FromQuery] string id)
        {
            Match? match = await _matchService.GetByIdAsync(id);

            if (match is null)
                return NotFound(id);

            if (!match.Shooter.Id.Equals(User.FindFirstValue(ClaimTypes.NameIdentifier)))
                return Unauthorized();

            match.Shots = await _shotService.GetMultiAsync(new(match.Shots.Select(x => x.Id)));
            match.Location = await _locationService.GetByIdAsync(match.Location.Id);
            return Ok(match.CreateDto());
        }

        [HttpGet, Route("match/get/by-user"),
         ProducesResponseType(StatusCodes.Status401Unauthorized),
         ProducesResponseType(StatusCodes.Status404NotFound),
         ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetMatchByUser()
        {
            string? id = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (id is null)
                return Unauthorized();

            List<Match> matches = await _matchService.GetByUserIdAsync(id);

            return matches.IsNullOrEmpty() ? NotFound(id) : Ok(matches.Convert<MatchOutputDto, Match>());
        }

        [HttpPost, Route("match/update"),
         ProducesResponseType(StatusCodes.Status201Created),
         ProducesResponseType(StatusCodes.Status400BadRequest),
         ProducesResponseType(StatusCodes.Status401Unauthorized),
         ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateMatch(
            [FromBody] MatchUpdateRequestDto updateRequest)
        {
            ModelState.ClearValidationState(nameof(updateRequest));

            if (TryValidateModel(updateRequest, nameof(updateRequest)))
            {
                Match? match = await _matchService.GetByIdAsync(updateRequest.Id);

                if (match is not null)
                {
                    if (match.Shooter.Id.Equals(User.FindFirstValue(ClaimTypes.NameIdentifier)))
                    {
                        if (Match.TotalShots.TryGetValue(updateRequest.Type, out int expectedShotTotal))
                        {
                            if (updateRequest.Shots.Count.Equals(expectedShotTotal))
                            {
                                match.AirPressure = updateRequest.AirPressure;
                                match.AirTemperature = updateRequest.AirTemperature;
                                match.WindDirection = updateRequest.WindDirection;
                                match.WindSpeed = updateRequest.WindSpeed;
                                match.EnvironmentNotes = updateRequest.EnvironmentNotes;
                                match.EquipmentNotes = updateRequest.EquipmentNotes;
                                match.ShooterNotes = updateRequest.ShooterNotes;

                                match.StartTimestamp =
                                    await _timestampService.GetByIdAsync(updateRequest.StartTimestampId);

                                match.EndTimestamp =
                                    await _timestampService.GetByIdAsync(updateRequest.EndTimestampId);

                                match.Location = await _locationService.GetByIdAsync(updateRequest.LocationId);

                                List<Shot> shots =
                                    await _shotService.GetMultiAsync(
                                        new(updateRequest.Shots.Select(x => x.Id)));

                                shots = shots.OrderBy(x => x.Position).ToList();

                                for (int i = 0; i < shots.Count; i++)
                                {
                                    if (updateRequest.Shots[i].Timestamp is not null)
                                    {
                                        shots[i].TimeStamp =
                                            await _timestampService.GetByIdAsync(
                                                updateRequest.Shots[i].Timestamp!.Id);
                                    }
                                    else shots[i].TimeStamp = null;

                                    shots[i].HorizontalDisplacement = updateRequest.Shots[i].HorizontalDisplacement;
                                    shots[i].VerticalDisplacement = updateRequest.Shots[i].VerticalDisplacement;
                                    shots[i].Value = updateRequest.Shots[i].Value;
                                }

                                match.Shots = shots;

                                await _shotService.UpdateShotsAsync(match.Shots);

                                await _matchService.UpdateMatchAsync(match);

                                return CreatedAtAction(
                                    nameof(GetMatchById),
                                    new { id = match.Id },
                                    match.CreateDto());
                            }

                            return BadRequest(updateRequest.Shots.Count);
                        }

                        return BadRequest(updateRequest.Type);
                    }

                    return Unauthorized();
                }

                return NotFound(updateRequest.Id);
            }

            return ValidationProblem(ModelState);
        }

        [HttpDelete, Route("match/delete"),
         ProducesResponseType(StatusCodes.Status200OK),
         ProducesResponseType(StatusCodes.Status401Unauthorized),
         ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteMatch([FromQuery] string id)
        {
            Match? match = await _matchService.GetByIdAsync(id);

            if (match is not null)
            {
                if (match.Shooter.Id.Equals(User.FindFirstValue(ClaimTypes.NameIdentifier)))
                {
                    await _matchService.DeleteSingleAsync(match);

                    return Ok();
                }

                return Unauthorized();
            }

            return NotFound(id);
        }

        [HttpDelete, Route("match/multi-delete"),
         ProducesResponseType(StatusCodes.Status200OK),
         ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> DeleteMultipleMatches([FromBody] List<string> ids)
        {
            List<Match> matches = await _matchService.GetMultipleByIdAsync(ids);

            if (matches.FirstOrDefault(
                    x => !x!.Shooter.Id.Equals(
                        User.FindFirstValue(ClaimTypes.NameIdentifier))) is null)
            {
                await _matchService.DeleteMultipleAsync(matches);

                return Ok();
            }

            return Unauthorized();
        }

        [AllowAnonymous, HttpGet, Route("test-connection")]
        public IActionResult Test([FromQuery] string test)
        {
            return Ok(test);
        }

        public DataController(
            CityService cityService,
            CountryService countryService,
            LocationService locationService,
            MatchService matchService,
            ShotService shotService,
            TimestampService timestampService,
            UserService userService)
        {
            this._cityService = cityService;
            this._countryService = countryService;
            this._locationService = locationService;
            this._matchService = matchService;
            this._shotService = shotService;
            this._timestampService = timestampService;
            this._userService = userService;
        }
    }
}

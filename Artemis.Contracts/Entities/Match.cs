using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace Artemis.Contracts.Entities
{
    public abstract class Match : IMatch
    {
        protected const int ShotsInSeries = 10;

        protected const int SeriesInPhase = 6;

        protected IMatchManager Manager = default!;

        protected List<IShot> Shots;

        [Key]
        public string Id { get; set; }

        [ForeignKey("ShooterId")]
        public User Shooter { get; set; } = default!;

        [ForeignKey("StartTimestampId")]
        public DateTime StartTimestamp { get; set; }

        [ForeignKey("EndTimestampId")]
        public DateTime EndTimestamp { get; set; }

        [ForeignKey("LocationId")]
        public Location Location { get; set; } = default!;

        public double? AirTemperature { get; set; }

        public double? AirPressure { get; set; }

        public double? WindSpeed { get; set; }

        public int? WindDirection { get; set; }

        public string? EnvironmentNotes { get; set; }

        public string? EquipmentNotes { get; set; }

        public string? ShooterNotes { get; set; }

        protected void InstantiateManager()
        {
            Manager = _3P50MatchManager.Instance;
        }

        public double GetNumberOfShotsInSeries() => ShotsInSeries;

        public double GetNumberOfSeriesInPhase()
        {
            throw new NotSupportedException();
        }

        public double GetNumberOfPhases()
        {
            throw new NotSupportedException();
        }

        public double GetNumberOfSeries()
        {
            throw new NotImplementedException();
        }

        public double GetNumberOfShotsInPhase()
        {
            throw new NotImplementedException();
        }

        public double GetNumberOfShots()
        {
            throw new NotImplementedException();
        }

        public IShot GetShotAt(int index)
        {
            throw new NotImplementedException();
        }

        public void AddShot(IShot shot)
        {
            throw new NotImplementedException();
        }

        public void AddShots(List<IShot> shots)
        {
            throw new NotImplementedException();
        }

        public List<IShot> GetShotsOfSeries(int index)
        {
            throw new NotImplementedException();
        }

        public List<IShot> GetShotsOfPhase(int index)
        {
            throw new NotImplementedException();
        }

        public ITuple GetSeriesResults(int index)
        {
            throw new NotImplementedException();
        }

        public List<ITuple> GetAllSeriesResults()
        {
            throw new NotImplementedException();
        }

        public List<ITuple> GetSeriesResultsOfPhase(int index)
        {
            throw new NotImplementedException();
        }

        public ITuple GetPhaseResults(int index)
        {
            throw new NotImplementedException();
        }

        public List<ITuple> GetAllPhaseResults()
        {
            throw new NotImplementedException();
        }

        public ITuple GetMatchResult()
        {
            throw new NotImplementedException();
        }

        protected Match()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Shots = new();
        }

        protected Match(
            User shooter,
            DateTime startTimestamp,
            DateTime endTimestamp,
            Location location,
            double? airTemperature = null,
            double? airPressure = null,
            double? windSpeed = null,
            int? windDirection = null,
            string? environmentNotes = null,
            string? equipmentNotes = null,
            string? shooterNotes = null)
            : this()
        {
            this.Shooter = shooter;
            this.StartTimestamp = startTimestamp;
            this.EndTimestamp = endTimestamp;
            this.Location = location;
            this.AirTemperature = airTemperature;
            this.AirPressure = airPressure;
            this.WindSpeed = windSpeed;
            this.WindDirection = windDirection;
            this.EnvironmentNotes = environmentNotes;
            this.EquipmentNotes = equipmentNotes;
            this.ShooterNotes = shooterNotes;
        }

        protected Match(
            string id,
            User shooter,
            DateTime startTimestamp,
            DateTime endTimestamp,
            Location location,
            double? airTemperature = null,
            double? airPressure = null,
            double? windSpeed = null,
            int? windDirection = null,
            string? environmentNotes = null,
            string? equipmentNotes = null,
            string? shooterNotes = null)
        {
            this.Id = id;
            this.Shooter = shooter;
            this.StartTimestamp = startTimestamp;
            this.EndTimestamp = endTimestamp;
            this.Location = location;
            this.AirTemperature = airTemperature;
            this.AirPressure = airPressure;
            this.WindSpeed = windSpeed;
            this.WindDirection = windDirection;
            this.EnvironmentNotes = environmentNotes;
            this.EquipmentNotes = equipmentNotes;
            this.ShooterNotes = shooterNotes;
            this.Shots = new();
        }
    }
}

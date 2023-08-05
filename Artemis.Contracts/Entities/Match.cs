using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace Artemis.Contracts.Entities
{
    public abstract class Match : IMatch
    {
        protected virtual IMatchManager Manager => TSMatchManager.Instance;

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

        protected virtual int ShotsInSeries => 10;

        protected virtual int SeriesInPhase => 6;

        public int GetNumberOfShotsInSeries() => ShotsInSeries;

        public virtual int GetNumberOfSeriesInPhase()
            => throw new NotSupportedException();

        public virtual int GetNumberOfPhases()
            => throw new NotSupportedException();

        public virtual int GetNumberOfSeries() => SeriesInPhase;

        public virtual int GetNumberOfShotsInPhase()
            => throw new NotSupportedException();

        public virtual int GetNumberOfShots() => ShotsInSeries * SeriesInPhase;

        public IShot GetShotAt(int index) => Shots[index];

        public void AddShot(IShot shot)
        {
            throw new NotImplementedException();
        }

        public void AddAllShots(List<IShot> shots)
        {
            throw new NotImplementedException();
        }

        public List<IShot> GetShotsOfSeries(int index) 
            => new(Shots.GetRange(
                ShotsInSeries * index, 
                ShotsInSeries));

        public virtual List<IShot> GetShotsOfPhase(int index)
            => throw new NotSupportedException();

        public virtual ITuple GetSeriesResults(int index)
        {
            throw new NotImplementedException();
        }

        public virtual List<ITuple> GetAllSeriesResults()
        {
            throw new NotImplementedException();
        }

        public virtual List<ITuple> GetSeriesResultsOfPhase(int index)
            => throw new NotSupportedException();

        public virtual ITuple GetPhaseResults(int index)
            => throw new NotSupportedException();

        public virtual List<ITuple> GetAllPhaseResults()
            => throw new NotSupportedException();

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
            List<IShot> shots,
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
            this.Shots = shots;
        }
    }
}

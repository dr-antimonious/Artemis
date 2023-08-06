using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using Artemis.Contracts.Entities.Interfaces;
using Artemis.Contracts.Entities.Managers;

namespace Artemis.Contracts.Entities.Matches
{
    public abstract class Match : IMatch
    {
        protected virtual IMatchManager Manager => TSMatchManager.Instance;

        protected List<IShot> Shots;

        [Key]
        public string Id { get; }

        [ForeignKey("UserId")]
        public User Shooter { get; set; } = default!;

        [ForeignKey("TimestampId")]
        public Timestamp StartTimestamp { get; set; } = default!;

        [ForeignKey("TimestampId")]
        public Timestamp EndTimestamp { get; set; } = default!;

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

        public virtual int GetNumberOfShots()
            => ShotsInSeries * SeriesInPhase;

        public IShot GetShotAt(int index) => Shots[index];

        public List<IShot> GetAllShots() => new(Shots);

        public void AddShot(IShot shot) => Shots.Add(shot);

        public void AddAllShots(List<IShot> shots) => Shots = shots;

        public List<IShot> GetShotsOfSeries(int index)
            => new(Shots.GetRange(
                ShotsInSeries * index,
                ShotsInSeries));

        public virtual List<IShot> GetShotsOfPhase(int index)
            => throw new NotSupportedException();

        public ITuple GetSeriesResults(int index)
            => Manager.GetSeriesResults(this, index);

        public List<ITuple> GetAllSeriesResults()
        {
            List<ITuple> results = new();
            for (int i = 0; i < GetNumberOfShots() / ShotsInSeries; i++)
                results.Add(GetSeriesResults(i));
            return results;
        }

        public virtual List<ITuple> GetSeriesResultsOfPhase(int index)
            => throw new NotSupportedException();

        public virtual ITuple GetPhaseResults(int index)
            => throw new NotSupportedException();

        public virtual List<ITuple> GetAllPhaseResults()
            => throw new NotSupportedException();

        public ITuple GetMatchResult()
            => Manager.GetMatchResult(this);

        public virtual int GetTotalBullseyeCount()
            => throw new NotSupportedException();

        public virtual int GetBullseyeCountOfShots(List<IShot> shots)
            => throw new NotSupportedException();

        protected Match()
        {
            Id = Guid.NewGuid().ToString();
            Shots = new();
        }

        protected Match(
            User shooter,
            Timestamp startTimestamp,
            Timestamp endTimestamp,
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
            Shooter = shooter;
            StartTimestamp = startTimestamp;
            EndTimestamp = endTimestamp;
            Location = location;
            AirTemperature = airTemperature;
            AirPressure = airPressure;
            WindSpeed = windSpeed;
            WindDirection = windDirection;
            EnvironmentNotes = environmentNotes;
            EquipmentNotes = equipmentNotes;
            ShooterNotes = shooterNotes;
        }

        protected Match(
            string id,
            User shooter,
            Timestamp startTimestamp,
            Timestamp endTimestamp,
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
            Id = id;
            Shooter = shooter;
            StartTimestamp = startTimestamp;
            EndTimestamp = endTimestamp;
            Location = location;
            AirTemperature = airTemperature;
            AirPressure = airPressure;
            WindSpeed = windSpeed;
            WindDirection = windDirection;
            EnvironmentNotes = environmentNotes;
            EquipmentNotes = equipmentNotes;
            ShooterNotes = shooterNotes;
            Shots = shots;
        }
    }
}

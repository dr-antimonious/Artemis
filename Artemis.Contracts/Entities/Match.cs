using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Artemis.Contracts.Entities
{
    public class Match
    {
        [Key]
        public string Id { get; set; } = default!;

        [ForeignKey("ShooterId")]
        public User Shooter { get; set; } = default!;

        [ForeignKey("StartTimestampId")]
        public DateTime StartTimestamp { get; set; } = default!;

        [ForeignKey("EndTimestampId")]
        public DateTime EndTimestamp { get; set; } = default!;

        [ForeignKey("LocationId")]
        public Location Location { get; set; } = default!;

        public double AirTemperature { get; set; } = default!;

        public double AirPressure { get; set; } = default!;

        public double WindSpeed { get; set; } = default!;

        public int WindDirection { get; set; } = default!;

        public string EnvironmentNotes { get; set; } = default!;

        public string EquipmentNotes { get; set; } = default!;

        public string ShooterNotes { get; set; } = default!;

        public Match()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public Match(
            User shooter,
            DateTime startTimestamp,
            DateTime endTimestamp,
            Location location,
            double airTemperature,
            double airPressure,
            double windSpeed,
            int windDirection,
            string environmentNotes,
            string equipmentNotes,
            string shooterNotes)
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

        public Match(
            string id,
            User shooter,
            DateTime startTimestamp,
            DateTime endTimestamp,
            Location location,
            double airTemperature,
            double airPressure,
            double windSpeed,
            int windDirection,
            string environmentNotes,
            string equipmentNotes,
            string shooterNotes)
            : this(
                shooter,
                startTimestamp,
                endTimestamp,
                location,
                airTemperature,
                airPressure,
                windSpeed,
                windDirection,
                environmentNotes,
                equipmentNotes,
                shooterNotes)
        {
            this.Id = id;
        }
    }
}

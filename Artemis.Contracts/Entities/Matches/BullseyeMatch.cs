using Artemis.Contracts.Entities.Interfaces;

namespace Artemis.Contracts.Entities.Matches
{
    public abstract class BullseyeMatch : Match
    {
        public const double BullseyeMinimum = 10.4;

        public override int GetTotalBullseyeCount()
            => Shots.Count(x => x.GetValue() >= BullseyeMinimum);

        public override int GetBullseyeCountOfShots(List<IShot> shots)
            => shots.Count(x => x.GetValue() >= BullseyeMinimum);

        protected BullseyeMatch() : base()
        {
        }

        protected BullseyeMatch(
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
            : base(
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
        }

        protected BullseyeMatch(
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
            : base(
                id,
                shooter,
                startTimestamp,
                endTimestamp,
                location,
                shots,
                airTemperature,
                airPressure,
                windSpeed,
                windDirection,
                environmentNotes,
                equipmentNotes,
                shooterNotes)
        {
        }
    }
}

namespace Artemis.Contracts.Entities
{
    public class _3P50Match : PhasedBullseyeMatch
    {
        protected new const int PhasesInMatch = 3;

        protected new const int SeriesInPhase = 4;

        public _3P50Match() : base()
        {
            InstantiateManager();
        }

        public _3P50Match(
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
            InstantiateManager();
        }

        public _3P50Match(
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
                airTemperature, 
                airPressure, 
                windSpeed, 
                windDirection, 
                environmentNotes, 
                equipmentNotes, 
                shooterNotes)
        {
            InstantiateManager();
            this.Shots = shots;
        }
    }
}

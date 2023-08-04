namespace Artemis.Contracts.Entities
{
    public class AR10Match : BullseyeMatch
    {
        private new void InstantiateManager()
        {
            Manager = AR10MatchManager.Instance;
        }

        public AR10Match() : base()
        {
            InstantiateManager();
        }

        public AR10Match(
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

        public AR10Match(
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

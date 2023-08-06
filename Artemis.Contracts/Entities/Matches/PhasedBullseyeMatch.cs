using System.Runtime.CompilerServices;
using Artemis.Contracts.Entities.Interfaces;

namespace Artemis.Contracts.Entities.Matches
{
    public abstract class PhasedBullseyeMatch : BullseyeMatch
    {
        protected override int SeriesInPhase => 3;

        protected virtual int PhasesInMatch => 2;

        public override int GetNumberOfSeriesInPhase() => SeriesInPhase;

        public override int GetNumberOfPhases() => PhasesInMatch;

        public override int GetNumberOfSeries() => SeriesInPhase * PhasesInMatch;

        public override int GetNumberOfShotsInPhase() => ShotsInSeries * SeriesInPhase;

        public override int GetNumberOfShots() => ShotsInSeries * SeriesInPhase * PhasesInMatch;

        public override List<IShot> GetShotsOfPhase(int index)
            => new(Shots.GetRange(
                SeriesInPhase * ShotsInSeries * index,
                ShotsInSeries * SeriesInPhase));

        public override List<ITuple> GetSeriesResultsOfPhase(int index)
        {
            List<ITuple> results = new();
            for (int i = SeriesInPhase * index; i < SeriesInPhase * (index + 1); i++)
                results.Add(GetSeriesResults(i));
            return results;
        }

        public override ITuple GetPhaseResults(int index)
            => Manager.GetPhaseResults(this, index);

        public override List<ITuple> GetAllPhaseResults()
        {
            List<ITuple> results = new();
            for (int i = 0; i < PhasesInMatch; i++)
                results.Add(GetPhaseResults(i));
            return results;
        }

        protected PhasedBullseyeMatch() : base()
        {
        }

        protected PhasedBullseyeMatch(
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

        protected PhasedBullseyeMatch(
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

using System.Runtime.CompilerServices;

namespace Artemis.Contracts.Entities
{
    public interface IMatch
    {
        double GetNumberOfShotsInSeries();

        double GetNumberOfSeriesInPhase();

        double GetNumberOfPhases();

        double GetNumberOfSeries();

        double GetNumberOfShotsInPhase();

        double GetNumberOfShots();

        IShot GetShotAt(int index);

        void AddShot(IShot shot);

        void AddShots(List<IShot> shots);

        List<IShot> GetShotsOfSeries(int index);

        List<IShot> GetShotsOfPhase(int index);

        ITuple GetSeriesResults(int index);

        List<ITuple> GetAllSeriesResults();

        List<ITuple> GetSeriesResultsOfPhase(int index);

        ITuple GetPhaseResults(int index);

        List<ITuple> GetAllPhaseResults();

        ITuple GetMatchResult();
    }
}

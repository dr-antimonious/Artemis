using System.Runtime.CompilerServices;
using Artemis.Contracts.Entities.Interfaces;

namespace Artemis.Contracts.Entities.Managers
{
    public abstract class MatchManager : IMatchManager
    {
        protected static double DecimalSeries(List<IShot> shots)
            => shots.Sum(x => x.Value);

        protected static int IntegerSeries(List<IShot> shots)
            => shots.Sum(x => (int)Math.Floor(x.Value));

        private static ITuple GetMultipleSeriesResult(List<ITuple> results)
            => new Tuple<List<ITuple>, int?, double?, int?>(
                results,
                results.Sum(x => (int?) x[0]),
                results.Sum(x => (double?) x[1]),
                results.Sum(x => (int?) x[2]));

        public ITuple GetMatchResult(IMatch match)
            => GetMultipleSeriesResult(match.GetAllSeriesResults());

        public virtual ITuple GetSeriesResults(IMatch match, int index)
            => throw new NotSupportedException();

        public virtual ITuple GetPhaseResults(IMatch match, int index)
            => GetMultipleSeriesResult(match.GetSeriesResultsOfPhase(index));

        protected MatchManager()
        {
        }
    }
}

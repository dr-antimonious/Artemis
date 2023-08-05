using System.Runtime.CompilerServices;
using Artemis.Contracts.Entities.Interfaces;
using Artemis.Contracts.Entities.Matches;

namespace Artemis.Contracts.Entities.Managers
{
    public abstract class MatchManager : IMatchManager
    {
        protected static int GetBullseyeCount(List<IShot> shots)
            => shots.Count(x => x.GetValue() >= BullseyeMatch.BullseyeMinimum);

        protected static ITuple DecimalSeries(List<IShot> shots)
            => (shots.Sum(x => x.GetValue()),
                GetBullseyeCount(shots));

        protected static ITuple IntegerSeries(List<IShot> shots)
            => (shots.Sum(x => (int)Math.Floor(x.GetValue())),
                GetBullseyeCount(shots));

        public virtual ITuple GetMatchResult(List<IShot> shots)
        {
            throw new NotImplementedException();
        }

        public virtual ITuple GetSeriesResults(List<IShot> shots, int index)
        {
            throw new NotImplementedException();
        }

        public virtual ITuple GetPhaseResults(List<IShot> shots, int index)
        {
            throw new NotImplementedException();
        }

        protected MatchManager()
        {
        }
    }
}

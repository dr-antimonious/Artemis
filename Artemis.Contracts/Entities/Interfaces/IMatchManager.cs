using System.Runtime.CompilerServices;

namespace Artemis.Contracts.Entities.Interfaces
{
    public interface IMatchManager
    {
        ITuple GetSeriesResults(List<IShot> shots, int index);

        ITuple GetPhaseResults(List<IShot> shots, int index);

        ITuple GetMatchResult(List<IShot> shots);
    }
}

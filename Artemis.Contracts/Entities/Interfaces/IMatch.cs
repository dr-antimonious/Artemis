﻿using System.Runtime.CompilerServices;

namespace Artemis.Contracts.Entities.Interfaces
{
    public interface IMatch
    {
        int GetNumberOfShotsInSeries();

        int GetNumberOfSeriesInPhase();

        int GetNumberOfPhases();

        int GetNumberOfSeries();

        int GetNumberOfShotsInPhase();

        int GetNumberOfShots();

        IShot GetShotAt(int index);

        List<IShot> GetAllShots();

        void AddShot(IShot shot);

        void AddAllShots(List<IShot> shots);

        List<IShot> GetShotsOfSeries(int index);

        List<IShot> GetShotsOfPhase(int index);

        ITuple GetSeriesResults(int index);

        List<ITuple> GetAllSeriesResults();

        List<ITuple> GetSeriesResultsOfPhase(int index);

        ITuple GetPhaseResults(int index);

        List<ITuple> GetAllPhaseResults();

        ITuple GetMatchResult();

        int GetTotalBullseyeCount();

        int GetBullseyeCountOfShots(List<IShot> shots);
    }
}

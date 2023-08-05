namespace Artemis.Contracts.Entities.Managers
{
    public class _3P50MatchManager : MatchManager
    {
        private static readonly Lazy<_3P50MatchManager> Lazy =
            new(() => new());

        public static _3P50MatchManager Instance => Lazy.Value;

        private _3P50MatchManager()
        {
        }
    }
}

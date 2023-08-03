namespace Artemis.Contracts.Entities
{
    public class P25MatchManager : MatchManager
    {
        private static readonly Lazy<P25MatchManager> Lazy =
            new(() => new());

        public static P25MatchManager Instance => Lazy.Value;

        private P25MatchManager()
        {
        }
    }
}

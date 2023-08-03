namespace Artemis.Contracts.Entities
{
    public class TSMatchManager : MatchManager
    {
        private static readonly Lazy<TSMatchManager> Lazy =
            new(() => new());

        public static TSMatchManager Instance => Lazy.Value;

        private TSMatchManager()
        {
        }
    }
}

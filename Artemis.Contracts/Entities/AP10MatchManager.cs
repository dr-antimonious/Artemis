namespace Artemis.Contracts.Entities
{
    public class AP10MatchManager : MatchManager
    {
        private static readonly Lazy<AP10MatchManager> Lazy =
            new(() => new());

        public static AP10MatchManager Instance => Lazy.Value;

        private AP10MatchManager()
        {
        }
    }
}

namespace Artemis.Contracts.Entities.Managers
{
    public class RFP25MatchManager : MatchManager
    {
        private static readonly Lazy<RFP25MatchManager> Lazy =
            new(() => new());

        public static RFP25MatchManager Instance => Lazy.Value;

        private RFP25MatchManager()
        {
        }
    }
}

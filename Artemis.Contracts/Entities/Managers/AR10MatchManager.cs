namespace Artemis.Contracts.Entities.Managers
{
    public class AR10MatchManager : MatchManager
    {
        private static readonly Lazy<AR10MatchManager> Lazy =
            new(() => new());

        public static AR10MatchManager Instance => Lazy.Value;

        private AR10MatchManager()
        {
        }
    }
}

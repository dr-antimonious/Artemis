namespace Artemis.Contracts.Entities.Interfaces
{
    public interface IShot
    {
        string Id { get; }

        Timestamp? TimeStamp { get; set; }

        double Value { get; set; }

        double? HorizontalDisplacement { get; set; }

        double? VerticalDisplacement { get; set; }
    }
}

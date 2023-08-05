namespace Artemis.Contracts.Entities.Interfaces
{
    public interface IShot
    {
        double GetValue();

        void SetValue(double value);

        double? GetHorizontalDisplacement();

        void SetHorizontalDisplacement(double displacement);

        double? GetVerticalDisplacement();

        void SetVerticalDisplacement(double displacement);

        DateTime? GetTimeStamp();

        void SetTimeStamp(DateTime timeStamp);
    }
}

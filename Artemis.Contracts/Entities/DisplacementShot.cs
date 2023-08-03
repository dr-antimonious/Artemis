namespace Artemis.Contracts.Entities
{
    public class DisplacementShot : BasicShot
    {
        private double _horizontalDisplacement = default!;

        private double _verticalDisplacement = default!;

        public DisplacementShot()
        {
        }

        public DisplacementShot(
            DateTime timeStamp,
            double value,
            double horizontalDisplacement,
            double verticalDisplacement)
            : base(
                timeStamp,
                value)
        {
            this._horizontalDisplacement = horizontalDisplacement;
            this._verticalDisplacement = verticalDisplacement;
        }

        public new double GetHorizontalDisplacement() => this._horizontalDisplacement;

        public new void SetHorizontalDisplacement(double horizontalDisplacement)
            => this._horizontalDisplacement = horizontalDisplacement;

        public new double GetVerticalDisplacement() => this._verticalDisplacement;

        public new void SetVerticalDisplacement(double verticalDisplacement)
            => this._verticalDisplacement = verticalDisplacement;
    }
}

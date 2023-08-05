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

        public override double GetHorizontalDisplacement() => this._horizontalDisplacement;

        public override void SetHorizontalDisplacement(double horizontalDisplacement)
            => this._horizontalDisplacement = horizontalDisplacement;

        public override double GetVerticalDisplacement() => this._verticalDisplacement;

        public override void SetVerticalDisplacement(double verticalDisplacement)
            => this._verticalDisplacement = verticalDisplacement;
    }
}

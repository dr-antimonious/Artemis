namespace Artemis.Contracts.Entities.Shots
{
    public class DisplacementShot : BasicShot
    {
        private double? _horizontalDisplacement;

        private double? _verticalDisplacement;

        public DisplacementShot()
        {
            this._horizontalDisplacement = null;
            this._verticalDisplacement = null;
        }

        public DisplacementShot(
            double value,
            DateTime? timeStamp = null,
            double? horizontalDisplacement = null,
            double? verticalDisplacement = null)
            : base(
                value,
                timeStamp)
        {
            _horizontalDisplacement = horizontalDisplacement;
            _verticalDisplacement = verticalDisplacement;
        }

        public override double? GetHorizontalDisplacement()
            => _horizontalDisplacement;

        public override void SetHorizontalDisplacement(double horizontalDisplacement)
            => _horizontalDisplacement = horizontalDisplacement;

        public override double? GetVerticalDisplacement()
            => _verticalDisplacement;

        public override void SetVerticalDisplacement(double verticalDisplacement)
            => _verticalDisplacement = verticalDisplacement;
    }
}

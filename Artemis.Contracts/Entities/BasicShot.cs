using System.ComponentModel.DataAnnotations;

namespace Artemis.Contracts.Entities
{
    public class BasicShot : IShot
    {
        private DateTime _timeStamp = default!;

        [Required]
        private double _value = default!;

        public BasicShot()
        {
        }

        public BasicShot(
            DateTime timeStamp,
            double value)
            : this()
        {
            this._timeStamp = timeStamp;
            this._value = value;
        }

        public double GetValue() => this._value;

        public void SetValue(double value) => this._value = value;

        public double GetHorizontalDisplacement()
        {
            throw new NotSupportedException();
        }

        public void SetHorizontalDisplacement(double displacement)
        {
            throw new NotSupportedException();
        }

        public double GetVerticalDisplacement()
        {
            throw new NotSupportedException();
        }

        public void SetVerticalDisplacement(double displacement)
        {
            throw new NotSupportedException();
        }

        public DateTime GetTimeStamp() => this._timeStamp;

        public void SetTimeStamp(DateTime timeStamp) => this._timeStamp = timeStamp;
    }
}

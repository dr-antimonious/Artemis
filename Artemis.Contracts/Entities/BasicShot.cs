using System.ComponentModel.DataAnnotations;

namespace Artemis.Contracts.Entities
{
    public class BasicShot : IShot
    {
        protected DateTime _timeStamp = default!;

        [Required]
        protected double _value = default!;

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

        public virtual double GetHorizontalDisplacement()
            => throw new NotSupportedException();

        public virtual void SetHorizontalDisplacement(double displacement)
            => throw new NotSupportedException();

        public virtual double GetVerticalDisplacement()
            => throw new NotSupportedException();

        public virtual void SetVerticalDisplacement(double displacement)
            => throw new NotSupportedException();

        public DateTime GetTimeStamp() => this._timeStamp;

        public void SetTimeStamp(DateTime timeStamp) => this._timeStamp = timeStamp;
    }
}

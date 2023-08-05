using System.ComponentModel.DataAnnotations;
using Artemis.Contracts.Entities.Interfaces;

namespace Artemis.Contracts.Entities.Shots
{
    public class BasicShot : IShot
    {
        protected DateTime? TimeStamp;

        [Required]
        protected double Value = default!;

        public BasicShot()
        {
            this.TimeStamp = null;
        }

        public BasicShot(
            double value,
            DateTime? timeStamp = null)
            : this()
        {
            this.TimeStamp = timeStamp;
            this.Value = value;
        }

        public double GetValue() => this.Value;

        public void SetValue(double value) => this.Value = value;

        public virtual double? GetHorizontalDisplacement()
            => throw new NotSupportedException();

        public virtual void SetHorizontalDisplacement(double displacement)
            => throw new NotSupportedException();

        public virtual double? GetVerticalDisplacement()
            => throw new NotSupportedException();

        public virtual void SetVerticalDisplacement(double displacement)
            => throw new NotSupportedException();

        public DateTime? GetTimeStamp() => this.TimeStamp;

        public void SetTimeStamp(DateTime timeStamp)
            => this.TimeStamp = timeStamp;
    }
}

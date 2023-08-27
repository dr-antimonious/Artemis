using System.ComponentModel.DataAnnotations;
using Artemis.Contracts.Entities;
using Artemis.Contracts.Entities.Interfaces;

namespace Artemis.Contracts.DTOs
{
    public class ShotDto : IConvertable<Shot>
    {
        [Required(ErrorMessage = "Shot value is required"),
        Range(0.0, 10.9)]
        public double Value { get; set; }

        public Timestamp? Timestamp { get; set; }

        public double? HorizontalDisplacement { get; set; }

        public double? VerticalDisplacement { get; set; }

        public virtual Shot Convert()
            => new(this);

        public ShotDto()
        {
        }

        public ShotDto(
            double value,
            Timestamp? timestamp = null,
            double? horizontalDisplacement = null,
            double? verticalDisplacement = null)
            : this()
        {
            Value = value;
            Timestamp = timestamp;
            HorizontalDisplacement = horizontalDisplacement;
            VerticalDisplacement = verticalDisplacement;
        }

        public ShotDto(Shot shot)
            : this(
                shot.Value,
                shot.TimeStamp,
                shot.HorizontalDisplacement,
                shot.VerticalDisplacement)
        {
        }
    }
}

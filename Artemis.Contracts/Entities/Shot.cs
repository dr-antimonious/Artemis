using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Artemis.Contracts.Entities
{
    public class Shot
    {
        [Required(ErrorMessage = "Shot must belong to an event")]
        [ForeignKey("EventId")]
        public Event Event { get; set; } = default!;

        [Required(ErrorMessage = "Number of shot is required")]
        [Range(1, ushort.MaxValue)]
        public ushort Number { get; set; } = default!;

        [Required(ErrorMessage = "Timestamp is required")]
        public DateTime TimeStamp { get; set; } = default!;

        [Required(ErrorMessage = "Decimal value is required")]
        [Range(0.0f, 10.9f)]
        public float Decimal { get; set; } = default!;

        [Required(ErrorMessage = "Horizontal displacement is required")]
        public float HorizontalDisplacement { get; set; } = default!;

        [Required(ErrorMessage = "Vertical displacement is required")]
        public float VerticalDisplacement { get; set; } = default!;

        public Shot()
        {
        }

        public Shot(
            Event shotEvent,
            ushort number,
            DateTime timeStamp,
            float result,
            float horizontalDisplacement,
            float verticalDisplacement)
            : this()
        {
            this.Event = shotEvent;
            this.Number = number;
            this.TimeStamp = timeStamp;
            this.Decimal = result;
            this.HorizontalDisplacement = horizontalDisplacement;
            this.VerticalDisplacement = verticalDisplacement;
        }
    }
}

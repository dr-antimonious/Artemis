using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Artemis.Contracts.Entities
{
    public class Shot
    {
        [ForeignKey("EventId")]
        public Event Event { get; set; } = default!;

        [Required]
        public int Number { get; set; } = default!;

        [Required]
        public DateTime TimeStamp { get; set; } = default!;

        [Required]
        public double Decimal { get; set; } = default!;

        [Required]
        public double HorizontalDisplacement { get; set; } = default!;

        [Required]
        public double VerticalDisplacement { get; set; } = default!;

        public Shot()
        {
        }

        public Shot(
            Event shotEvent,
            int number,
            DateTime timeStamp,
            double result,
            double horizontalDisplacement,
            double verticalDisplacement)
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

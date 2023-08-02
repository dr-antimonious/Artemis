using System.ComponentModel.DataAnnotations;

namespace Artemis.Contracts.Entities
{
    public class Shot
    {
        [Required]
        public int Number { get; set; } = default!;

        public DateTime TimeStamp { get; set; } = default!;

        [Required]
        public double Decimal { get; set; } = default!;

        public double HorizontalDisplacement { get; set; } = default!;

        public double VerticalDisplacement { get; set; } = default!;

        public Shot()
        {
        }

        public Shot(
            int number,
            DateTime timeStamp,
            double result,
            double horizontalDisplacement,
            double verticalDisplacement)
            : this()
        {
            this.Number = number;
            this.TimeStamp = timeStamp;
            this.Decimal = result;
            this.HorizontalDisplacement = horizontalDisplacement;
            this.VerticalDisplacement = verticalDisplacement;
        }
    }
}

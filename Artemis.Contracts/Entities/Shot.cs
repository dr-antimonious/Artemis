using System.ComponentModel.DataAnnotations;
using Artemis.Contracts.Entities.Interfaces;

namespace Artemis.Contracts.Entities
{
    public class Shot : IShot
    {
        [Key]
        public string Id { get; }

        public Timestamp? TimeStamp { get; set; }

        [Required]
        public double Value { get; set; }

        public double? HorizontalDisplacement { get; set; }

        public double? VerticalDisplacement { get; set; }

        public Shot()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public Shot(
            double value,
            Timestamp? timeStamp = null,
            double? horizontalDisplacement = null,
            double? verticalDisplacement = null)
            : this()
        {
            this.Value = value;
            this.TimeStamp = timeStamp;
            this.HorizontalDisplacement = horizontalDisplacement;
            this.VerticalDisplacement = verticalDisplacement;
        }

        public Shot(
            string id, 
            double value, 
            Timestamp? timeStamp = null, 
            double? horizontalDisplacement = null, 
            double? verticalDisplacement = null)
        {
            this.Id = id;
            this.TimeStamp = timeStamp;
            this.Value = value;
            this.HorizontalDisplacement = horizontalDisplacement;
            this.VerticalDisplacement = verticalDisplacement;
        }
    }
}

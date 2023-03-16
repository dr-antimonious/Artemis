using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Artemis.Contracts.Entities
{
    public class Exercise
    {
        [Key]
        public string Id { get; set; } = default!;

        [Required(ErrorMessage = "Training is required")]
        [ForeignKey("TrainingId")]
        public Event Training { get; set; } = default!;

        [Required(ErrorMessage = "Type is required")]
        [ForeignKey("TypeId")]
        public ExerciseType Type { get; set; } = default!;

        [Required(ErrorMessage = "Dry shot count is required")]
        [Range(ushort.MinValue, ushort.MaxValue)]
        public ushort DryShotCount { get; set; } = default!;

        [Required(ErrorMessage = "Shot count is required")]
        [Range(ushort.MinValue, ushort.MaxValue)]
        public ushort ShotCount { get; set; } = default!;

        [Required(ErrorMessage = "Performance is required")]
        [Range(1, 10)]
        public byte Performance { get; set; } = default!;

        public Exercise()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public Exercise(
            Event training,
            ExerciseType type,
            ushort dryShotCount,
            ushort shotCount,
            byte performance)
            : this()
        {
            this.Training = training;
            this.Type = type;
            this.DryShotCount = dryShotCount;
            this.ShotCount = shotCount;
            this.Performance = performance;
        }

        public Exercise(
            string id,
            Event training,
            ExerciseType type,
            ushort dryShotCount,
            ushort shotCount,
            byte performance)
            : this(
                training,
                type,
                dryShotCount,
                shotCount,
                performance)
        {
            this.Id = id;
        }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Artemis.Contracts.Entities
{
    public class Exercise
    {
        [Key]
        public string Id { get; set; } = default!;

        [ForeignKey("TrainingId")]
        public Event Training { get; set; } = default!;

        [ForeignKey("TypeId")]
        public ExerciseType Type { get; set; } = default!;

        [Required]
        public int DryShotCount { get; set; } = default!;

        [Required]
        public int ShotCount { get; set; } = default!;

        [Required]
        [Range(1, 10)]
        public int Performance { get; set; } = default!;

        public Exercise()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public Exercise(
            Event training,
            ExerciseType type,
            int dryShotCount,
            int shotCount,
            int performance)
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
            int dryShotCount,
            int shotCount,
            int performance)
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

using System.ComponentModel.DataAnnotations;

namespace Artemis.Contracts.Entities
{
    public class ExerciseType
    {
        [Key]
        public string Id { get; set; } = default!;

        [Required]
        public string Name { get; set; } = default!;

        public string Description { get; set; } = default!;

        public ExerciseType()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public ExerciseType(string name, string description)
            : this()
        {
            this.Name = name;
            this.Description = description;
        }

        public ExerciseType(string id, string name, string description)
            : this(name, description)
        {
            this.Id = id;
        }
    }
}

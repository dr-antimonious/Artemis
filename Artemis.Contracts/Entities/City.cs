using System.ComponentModel.DataAnnotations;

namespace Artemis.Contracts.Entities
{
    public class City
    {
        [Key]
        public string Id { get; set; } = default!;

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = default!;

        public City()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public City(string name)
            : this()
        {
            this.Name = name;
        }

        public City(string id, string name)
            : this(name)
        {
            this.Id = id;
        }
    }
}

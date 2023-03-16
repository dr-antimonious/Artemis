using System.ComponentModel.DataAnnotations;

namespace Artemis.Contracts.Entities
{
    public class Country
    {
        [Key]
        public string Id { get; set; } = default!;

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = default!;

        public Country()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public Country(string name)
            : this()
        {
            this.Name = name;
        }

        public Country(string id, string name)
            : this(name)
        {
            this.Id = id;
        }
    }
}

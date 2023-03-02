﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Artemis.Contracts.Entities
{
    public class Event
    {
        [Key]
        public string Id { get; set; } = default!;

        [ForeignKey("CoachId")]
        public User Coach { get; set; } = default!;

        [ForeignKey("ShooterId")]
        public User Shooter { get; set; } = default!;

        [ForeignKey("DateId")]
        public DateTime Date { get; set; } = default!;

        [ForeignKey("LocationId")]
        public Location Location { get; set; } = default!;

        [Required]
        public string Notes { get; set; } = default!;

        [Required]
        public bool IsMatch { get; set; } = default!;

        public Event()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public Event(
            User coach,
            User shooter,
            DateTime date,
            Location location,
            string notes,
            bool isMatch)
            : this()
        {
            this.Coach = coach;
            this.Shooter = shooter;
            this.Date = date;
            this.Location = location;
            this.Notes = notes;
            this.IsMatch = isMatch;
        }

        public Event(
            string id,
            User coach,
            User shooter,
            DateTime date,
            Location location,
            string notes,
            bool isMatch)
            : this(
                coach,
                shooter,
                date,
                location,
                notes,
                isMatch)
        {
            this.Id = id;
        }
    }
}

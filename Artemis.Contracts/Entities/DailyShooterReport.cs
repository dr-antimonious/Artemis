using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Artemis.Contracts.Entities
{
    public class DailyShooterReport
    {
        [Key]
        public string Id { get; set; } = default!;

        [ForeignKey("ShooterId")]
        public User Shooter { get; set; } = default!;

        [ForeignKey("DateId")]
        public DateTime Date { get; set; } = default!;

        [ForeignKey("DrugReportId")]
        public DailyDrugReport DrugReport { get; set; } = default!;

        [ForeignKey("ExerciseReportId")]
        public DailyExerciseReport ExerciseReport { get; set; } = default!;

        [ForeignKey("MentalReportId")]
        public DailyMentalReport MentalReport { get; set; } = default!;

        [ForeignKey("NutritionReportId")]
        public DailyNutritionReport NutritionReport { get; set; } = default!;

        [ForeignKey("PhysicalReportId")]
        public DailyPhysicalReport PhysicalReport { get; set; } = default!;
    }
}

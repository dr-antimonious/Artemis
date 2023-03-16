using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Artemis.Contracts.Entities
{
    public class DailyShooterReport
    {
        [Key]
        public string Id { get; set; } = default!;

        [Required(ErrorMessage = "Shooter is required")]
        [ForeignKey("ShooterId")]
        public User Shooter { get; set; } = default!;

        [Required(ErrorMessage = "Date is required")]
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

        public DailyShooterReport()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public DailyShooterReport(
            User shooter,
            DateTime date,
            DailyDrugReport drugReport,
            DailyExerciseReport exerciseReport,
            DailyMentalReport mentalReport,
            DailyNutritionReport nutritionReport,
            DailyPhysicalReport physicalReport)
            : this()
        {
            this.Shooter = shooter;
            this.Date = date;
            this.DrugReport = drugReport;
            this.ExerciseReport = exerciseReport;
            this.MentalReport = mentalReport;
            this.NutritionReport = nutritionReport;
            this.PhysicalReport = physicalReport;
        }

        public DailyShooterReport(
            string id,
            User shooter,
            DateTime date,
            DailyDrugReport drugReport,
            DailyExerciseReport exerciseReport,
            DailyMentalReport mentalReport,
            DailyNutritionReport nutritionReport,
            DailyPhysicalReport physicalReport)
            : this(
                shooter,
                date,
                drugReport,
                exerciseReport,
                mentalReport,
                nutritionReport,
                physicalReport)
        {
            this.Id = id;
        }
    }
}

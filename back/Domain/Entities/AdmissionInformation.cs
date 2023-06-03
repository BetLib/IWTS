namespace Domain.Entities
{
    public class AdmissionInformation
    {
        public int Id { get; set; }

        public FieldStudy FieldStudy { get; set; }

        public int Year { get; set; }

        public int NumberOfBudgetPlaces { get; set; }

        public int NumberOfCommertialPlaces { get; set; }

        public int NumberOfHalfPaidPlaces { get; set; }

        public decimal Cost { get; set; }

        public ICollection<PassingScore> PassingScores { get; set; }
    }
}

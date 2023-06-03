using Domain.Constants;

namespace Domain.Entities
{
    public class Subject
    {
        public SubjectId Id { get; set; }

        public string Name { get; set; }

        public ICollection<ExamPass> ExamPasses { get; set; }

        public ICollection<PassingScore> PassingScores { get; set; }
    }
}

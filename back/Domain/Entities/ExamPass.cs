using Domain.Constants;

namespace Domain.Entities
{
    public class ExamPass
    {
        public int StudentId { get; set; }

        public Student Student { get; set; }

        public SubjectId SubjectId { get; set; }

        public Subject Subject { get; set; }

        public int Result { get; set; }
    }
}

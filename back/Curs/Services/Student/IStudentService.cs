using Curs.Models;
using Domain.Constants;

namespace Curs.Repository.Users
{
    public interface IStudentService
    {
        public Task Registration(string login, string password);

        public Task AddExamResult(int studentId, SubjectId subjectId, int result);

        public Task<CalculateCostResult> CalculateCost(int studentId, int studyFieldId, ICollection<SubjectId> subjectsIds);
    }
}

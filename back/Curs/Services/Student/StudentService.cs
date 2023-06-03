using Curs.Constants;
using Curs.Infrastracture;
using Curs.Infrastracture.Exceptions;
using Curs.Models;
using Domain;
using Domain.Constants;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text.RegularExpressions;

namespace Curs.Repository.Users
{
    public class StudentService : IStudentService
    {
        private readonly Regex SnilsRegex = new Regex(@"^\d{11}$");
        private readonly Regex InnRegex = new Regex(@"^\d{12}$");

        private readonly ApplicationDbContext dbContext;

        public StudentService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Registration(string login, string password)
        {
            login = login.Trim();

            var matchSnils = SnilsRegex.Match(login);
            var matchInn = InnRegex.Match(login);
            if (!matchSnils.Success && !matchInn.Success)
            {
                throw new IwtsException("Неправильно введен логин");
            }

            var user = new UserEntity()
            {
                Login = login,
                Password = AuthHelper.GetPasswordHash(password),
            };
            var student = new Student()
            {
                User = user,
                Inn = matchInn.Success ? login : null,
                Snils = matchSnils.Success ? login : null,
            };
            await dbContext.AddAsync(user);
            await dbContext.Students.AddAsync(student);
            await dbContext.SaveChangesAsync();
        }

        public async Task AddExamResult(int studentId, SubjectId subjectId, int result)
        {
            var examPass = new ExamPass()
            {
                StudentId = studentId,
                SubjectId = subjectId,
                Result = result
            };
          
            await dbContext.AddAsync(examPass);
            await dbContext.SaveChangesAsync();
        }

        public async Task<CalculateCostResult> CalculateCost(int studentId, int studyFieldId, ICollection<SubjectId> subjectsIds)
        {
            var examPasses = await dbContext.ExamPasses
                .Where(p => p.StudentId == studentId)
                .Where(p => subjectsIds.Contains(p.SubjectId))
                .ToArrayAsync();
            var main = examPasses.Where(examPass => SubjectHelper.IsMain(examPass.SubjectId)).ToArray();
            var additional = examPasses.Except(main).First();

            var resultsSum = examPasses.Sum(s => s.Result);
            var passingScores = await dbContext.PassingScores
                .Where(ps => subjectsIds.Contains(ps.Subject.Id))
                .Where(ps => ps.AdmissionInformation.FieldStudy.Id == studyFieldId && ps.AdmissionInformation.Year == DateTime.Now.Year)
                .Include(ps => ps.Subject)
                .ToListAsync();

            ThrowIfNoPass(examPasses, passingScores);

            var passingScoreSum = passingScores.Sum(s => s.Score);
            var additionalPassingScore = passingScores.First(ps => ps.Subject.Id == additional.SubjectId).Score;

            var admissionInformations = await dbContext.AdmissionInformations
                .Where(admissionInformation => admissionInformation.FieldStudy.Id == studyFieldId)
                .Where(admissionInformation => admissionInformation.Year == DateTime.Now.Year)
                .FirstOrDefaultAsync();
            if (admissionInformations == null)
            {
                throw new IwtsException("Не данных об запрашиваемом направлении");
            }

            var costs = admissionInformations.Cost;

            var kolbudget = admissionInformations.NumberOfBudgetPlaces;

            var discount = (resultsSum * additional.Result * costs) / (passingScoreSum * additionalPassingScore * kolbudget);

            var field_study = dbContext.FieldStudies.FirstOrDefault(p => p.Id == studyFieldId);

            var results = new CalculateCostResult()
            {
                Cost = costs,
                Discount = discount,
                TotalCost= costs - discount
            };
             return results;
        }

        private void ThrowIfNoPass(ICollection<ExamPass> examPasses, ICollection<PassingScore> passingScores)
        {
            foreach (var examPass in examPasses)
            {
                var passingScore = passingScores.First(ps => ps.Subject.Id == examPass.SubjectId);
                if (passingScore.Score > examPass.Result)
                {
                    throw new IwtsException($"Недостаточно баллов для прохождения по предменту '{passingScore.Subject.Name}'");
                }
            }
        }
    }
}

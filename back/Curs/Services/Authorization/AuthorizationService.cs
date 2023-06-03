using Curs.Infrastracture;
using Curs.Infrastracture.Exceptions;
using Curs.Models;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Curs.Services.Authorization
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly ApplicationDbContext dbContext;
        public AuthorizationService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<string> Authorization(string login, string password)
        {
            var passwordHash = AuthHelper.GetPasswordHash(password);
            var user = await dbContext.Users.FirstOrDefaultAsync(p => 
                p.Login.ToUpper() == login.ToUpper() 
                && p.Password == passwordHash);
            if (user == null)
            {
                throw new IwtsException("Неправильный логин или пароль");
            }

            var student = await dbContext.Students.FirstOrDefaultAsync(s => s.User.Id == user.Id);

            return AuthHelper.GetToken(new User(user, student));
        }
    }
}

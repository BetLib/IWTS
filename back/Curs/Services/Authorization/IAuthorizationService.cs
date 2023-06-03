namespace Curs.Services.Authorization
{
    public interface IAuthorizationService
    {
        public Task<string> Authorization(string login, string password);
    }
}

using Domain.Entities;

namespace Curs.Models
{
    public class User
    {
        public User() 
        {
        }

        public User(UserEntity user, Student? student)
        {
            Id = user.Id;
            Login = user.Login;
            Password = user.Password;
            Student = student;
        }

        public int Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public Student? Student { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public  class Student
    {
        public int Id { get; set; }

        public string? Snils { get; set; }

        public string? Inn { get; set; }

        public ICollection<ExamPass> ExamPasses { get; set; }

        public UserEntity User { get; set; }  
    }
}

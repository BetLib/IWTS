using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class EducationLevel
    {
        public int Id { get; set; }

        public string LevelEducation { get; set; }

        public ICollection<FieldStudy> FieldStudies { get; set; }
    }
}

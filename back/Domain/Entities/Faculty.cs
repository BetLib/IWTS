using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Faculty
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public University University { get; set; }

        public ICollection<FieldStudy> FieldStudies { get; set; }
    }
}

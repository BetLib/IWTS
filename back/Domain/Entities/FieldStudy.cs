using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    /// <summary>
    /// Направления
    /// </summary>
    public class FieldStudy
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Faculty Faculty { get; set; }

        public EducationLevel EducationLevel { get; set; }

        public bool FullTime { get; set; }

        public ICollection<AdmissionInformation> AdmissionInformations { get; set; }
    }
}

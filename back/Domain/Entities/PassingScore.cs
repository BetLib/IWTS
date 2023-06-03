using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PassingScore
    {
        public int Id { get; set; }

        public AdmissionInformation AdmissionInformation { get; set; }

        public Subject Subject { get; set; }

        public int Score { get; set; }
    }
}

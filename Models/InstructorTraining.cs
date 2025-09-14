using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportClub.Models
{
    public class InstructorTraining
    {
        public int IdInstructor { get; set; }
        public Instructor Instructor { get; set; }

        public int IdTraining { get; set; }
        public Training Training { get; set; }
    }
}
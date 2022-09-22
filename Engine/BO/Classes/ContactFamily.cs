using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Service.DataCollector;
using Engine.Interfaces.DataCollector;

namespace Engine.BO
{
    public class ContactFamily : BaseBO 
    {
        private IStudentCollector StudentService => StudentCollector.Instance(StudentId);
        private int StudentId { get; set; }

        public Contact? Contact { get; set; }
        public string? Name { get; set; }
        public string? Kinship { get; set; }
        public string? Work { get; set; }
        public bool? IsEmergency { get; set; }
        public Student? Student => StudentService.Student;

        public ContactFamily(int studentId) => StudentId = studentId;

        public ContactFamily()
        {
            Contact = null;
            Name = string.Empty;
            Kinship = string.Empty;
            Work = string.Empty;
        }
    }
}

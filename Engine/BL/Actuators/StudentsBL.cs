using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.DAL;
using Engine.BO;
using Engine.BL;

namespace Engine.BL
{
    public class StudentsBL : BaseBL
    {        

        public static List<Student> GetStudents(int? id = null) 
            => Dal.GetStudents(id);

        public static List<Student> GetGroupStudents(int groupId) 
            => Dal.GetGroupStudents(groupId);

        public static Student? GetStudent(int id) 
            => GetStudents(id).FirstOrDefault();

    }
}

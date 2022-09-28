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
        {
            var students = Dal.GetStudents(id);

            foreach(var s in students)
                CompleteStudent(s);

            return students;
        }

        public static List<Student> GetGroupStudents(int groupId) 
            => Dal.GetGroupStudents(groupId);

        public static Student? GetStudent(int id) 
            => GetStudents(id).FirstOrDefault();

        private static void CompleteStudent(Student? s)
        {
            if(s != null && s.IsValid() && s.Marital != null && s.Genre != null && s.Address != null)
            {
                s.Marital = CatalogsBL.GetAsset(s.Marital.Id);
                s.Genre = CatalogsBL.GetAsset(s.Genre.Id);
                s.Address = CatalogsBL.GetAddress(s.Address.Id);
                s.Scholarly = null;
                s.Labor = null;
                s.BirthPlace = null;
            }
        }

    }
}

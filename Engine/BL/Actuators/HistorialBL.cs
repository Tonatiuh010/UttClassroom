using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Engine.BO;

namespace Engine.BL
{
    public class HistorialBL : BaseBL
    {
        public static List<StudentHistory> GetStudentHistorial(int? id = null, string? group = null, string? subGroup = null)
            => Dal.GetStudentHistorial(id, group, subGroup);

        public static List<int> GetStudentGrades(int studentId, string group, string subGroup)
        {
            List<int> grades = new();
            var historial = GetStudentHistorial(id: studentId, group: group, subGroup: subGroup);
            
            foreach(var h in historial)
                grades.Add(h.GetScore<int>());
            
            return grades;
        }

        public static List<ItemStats> GetStudentStats(int studentId)
        {
            var scholarly = GetStudentHistorial(id: studentId, group: "", subGroup: "");
            var english = GetStudentHistorial(id: studentId, group: "", subGroup: "");
            var preExam = GetStudentHistorial(id: studentId, group: "", subGroup: "");
            var tsuGrades = GetStudentGrades(studentId, "", "");
            var engGrades = GetStudentGrades(studentId, "", "");

            //new ItemStats("QuarterGrades", grades)

            return new List<ItemStats>()
            {
                
            };
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Engine.BO;
using Engine.Constants;

namespace Engine.BL
{
    public class HistorialBL : BaseBL
    {
        public static List<StudentHistory> GetStudentHistorial(int? id = null, string? group = null, string? subGroup = null)
            => Dal.GetStudentHistorial(id, group, subGroup);

        public static List<double> GetStudentGrades(int studentId, string group, string subGroup)
        {
            List<double> grades = new();
            var historial = GetStudentHistorial(id: studentId, group: group, subGroup: subGroup);

            foreach (var h in historial)
                grades.Add(h.GetScore());

            return grades;
        }

        public static List<ItemStats> GetStudentStats(int studentId)
        {
            var scholarly = GetStudentHistorial(id: studentId, group: C.TSU, subGroup: C.SCHOLARLY);
            var english = GetStudentHistorial(id: studentId, group: C.TSU, subGroup: C.ENGLISH);
            var preExam = GetStudentHistorial(id: studentId, group: C.TSU, subGroup: C.SCHOLARLY);            

            var tsuGrades = GetStudentGrades(studentId, C.TSU, C.QUARTER);
            var engGrades = GetStudentGrades(studentId, C.ING, C.QUARTER);

            //new ItemStats("QuarterGrades", grades)

            return new List<ItemStats>()
            {
                new ItemStats("scholarly", scholarly[0].Score),
                new ItemStats("english", english[0].Score),
                new ItemStats("preExam", preExam[0].Score),
                new ItemStats("tsuGrades", tsuGrades),
                new ItemStats("engGrades", engGrades),

                new ItemStats("tsuAvg", tsuGrades.Average()),
                new ItemStats("engAvg", engGrades.Average())

            };

        }

        public static List<ItemStats> GetGroupStats()
        {
            //new ItemStats("QuarterGrades", grades)

            return new List<ItemStats>()
            {
                new ItemStats("alumns", 20),

                //personal information
                new ItemStats("personal information", 1),
                new ItemStats("genre", 2),
                new ItemStats("marital status", 2),
                new ItemStats("lives with...", 2),
                new ItemStats("family income", 2),

                //labor data
                new ItemStats("labor data", 2),
                new ItemStats("they work?", 2),
                new ItemStats("workRelatedStudies", 2),
                new ItemStats("workReason", 2),

                //school data
                new ItemStats("school data", 3),
                new ItemStats("highSchoolType", 3),
                new ItemStats("highSchools", 3),

                //averages
                new ItemStats("averages", 4),
                new ItemStats("highSchool", 4),
                new ItemStats("tsu", 4),
                new ItemStats("engineering", 4),


            };

        }

    }
}

/*new ItemStats("genre", new ItemStats("Masculino", 22)),
new ItemStats("genre", new ItemStats("Femenino", 7)),*/
using System;
using System.Collections.Generic;
using System.Linq;
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
            var preExam = GetStudentHistorial(id: studentId, group: C.TSU, subGroup: C.EXAM_ENTRY);            

            var tsuGrades = GetStudentGrades(studentId, C.TSU, C.QUARTER);
            var engGrades = GetStudentGrades(studentId, C.ING, C.QUARTER);            

            return new List<ItemStats>()
            {
                new (
                    "tsu", 
                    ItemStats.ToJsonObject( new List<ItemStats>() {
                        new ("scholarly", scholarly[0].Score),
                        new ("english", english[0].Score),
                        new ("preExam", preExam[0].Score),
                        new ("tsuGrades", tsuGrades),
                        new ("tsuAvg", tsuGrades.Average()),
                    }) 
                ),

                 new (
                    "eng",
                    ItemStats.ToJsonObject( new List<ItemStats>() {
                        new ("engGrades", engGrades),
                        new ("engAvg", engGrades.Average())
                    })
                ),                

            };

        }

    }
}

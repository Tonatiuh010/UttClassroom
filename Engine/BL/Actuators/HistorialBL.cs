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

        public static List<ItemStats> GetGroupStats()
        {
            return new List<ItemStats>()
            {
                new ItemStats("students", 29),
                new ItemStats(
                    "personal_information",
                    ItemStats.ToJsonObject(new List<ItemStats> {
                        new ItemStats("genre", new List<ItemStats> {
                            new (CatalogsBL.GetAsset("GN-F")?.Name, 22),
                            new (CatalogsBL.GetAsset("GN-M")?.Name, 7),
                        }),
                        new ItemStats("marital", new List<ItemStats> {
                            new (CatalogsBL.GetAsset("EC-SLT")?.Name, 28),
                            new (CatalogsBL.GetAsset("")?.Name, 1),
                        }),
                        new ItemStats("lives_with", new List<ItemStats> {
                            new (CatalogsBL.GetAsset("")?.Name, 19),
                            new (CatalogsBL.GetAsset("")?.Name, 7),
                            new (CatalogsBL.GetAsset("")?.Name, 2),
                            new (CatalogsBL.GetAsset("")?.Name, 1),
                        }),
                        new ItemStats("family_income", new List<ItemStats> {
                            new (CatalogsBL.GetAsset("")?.Name, 18),
                            new (CatalogsBL.GetAsset("")?.Name, 7),
                            new (CatalogsBL.GetAsset("")?.Name, 2),
                            new (CatalogsBL.GetAsset("")?.Name, 2),
                        }),
                    })
                ),
                new ItemStats(
                    "labor_data",
                    ItemStats.ToJsonObject(new List<ItemStats> {
                        new (
                            "work",
                            ItemStats.ToJsonObject(new () {
                                new ("yes", 9),
                                new ("no", 20)
                            })
                        ),
                        new (
                            "workStudy",
                            ItemStats.ToJsonObject(new () {
                                new ("yes", 5),
                                new ("no", 4)
                            })
                        ),
                        new (
                            "workReason",
                            new List<ItemStats>() {
                                new (CatalogsBL.GetAsset("")?.Name, 4),
                                new (CatalogsBL.GetAsset("")?.Name, 3),
                                new (CatalogsBL.GetAsset("")?.Name,1),
                                new (CatalogsBL.GetAsset("")?.Name, 1)
                            })
                    })
                ),              
                new ItemStats(
                    "scholarlyData",
                    ItemStats.ToJsonObject(new List<ItemStats> {
                        new ("scholarlyType", new List<ItemStats> () {
                            new (CatalogsBL.GetAsset("")?.Name, 27),
                            new (CatalogsBL.GetAsset("")?.Name, 2),
                        }),
                         new ("scholarly", new List<ItemStats> () {
                            new ("", 3),
                            new ("", 5),
                            new ("", 7),
                            new ("", 10),
                            new ("", 2),
                            new ("", 1),
                            new ("", 2),
                            new ("", 4),
                        })
                    })
                ),
            };

        }

    }
}

/*new ItemStats("genre", new ItemStats("Masculino", 22)),
new ItemStats("genre", new ItemStats("Femenino", 7)),*/
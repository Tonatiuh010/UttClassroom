﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Services.DataCollector;
using Engine.BL;

namespace Engine.BL
{
    public static class BinderBL
    {
        public static void Start()
        {
            AssetCollector.SearchAsset = CatalogsBL.GetAsset;
            GroupStudentsCollector.SearchStudents = StudentsBL.GetGroupStudents;
            StudentCollector.SearchStudent = id => StudentsBL.GetStudent(id).GetBase();
            HistorialCollector.SearchHistorial =  id => HistorialBL.GetStudentHistorial(id: id);
            HistorialCollector.SearchStats = HistorialBL.GetStudentStats;
            ContactFamilyCollector.SearchContactFamily = id => {
                var contacts = CatalogsBL.GetContactFamilies(id: id);
                return contacts.Select(x => x.GetBase()).ToList();
            };
        }
    }
}

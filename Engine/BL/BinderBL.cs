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
            StudentCollector.SearchStudent = StudentsBL.GetStudent;
        }
    }
}